using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

namespace RepairRequestor.services
{
    /// <summary>
    /// Ошибка доступа к файлу базы данных (файл отсутствует или повреждён).
    /// </summary>
    internal sealed class DatabaseUnavailableException : Exception
    {
        public DatabaseUnavailableException(string message)
            : base(message)
        {
        }

        public DatabaseUnavailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Единая точка доступа к SQLite-базе db/repair.db.
    /// </summary>
    internal static class DatabaseHandler
    {
        private const string DatabaseFolder = "db";
        private const string DatabaseFileName = "repair.db";

        private static string cachedDatabasePath;

        static DatabaseHandler()
        {
            // Явная инициализация нативного провайдера SQLite (bundle_e_sqlite3).
            SQLitePCL.Batteries_V2.Init();
        }

        /// <summary>
        /// Путь к файлу базы данных. Файл ищется вверх по дереву каталогов от папки приложения.
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                if (cachedDatabasePath == null)
                {
                    cachedDatabasePath = ResolveDatabasePath();
                }

                return cachedDatabasePath;
            }
        }

        public static string ConnectionString
        {
            get { return "Data Source=" + DatabasePath + ";Mode=ReadWrite"; }
        }

        public static bool DatabaseExists()
        {
            return File.Exists(DatabasePath);
        }

        private static string ResolveDatabasePath()
        {
            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (directory != null)
            {
                string candidate = Path.Combine(directory.FullName, DatabaseFolder, DatabaseFileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                directory = directory.Parent;
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFolder, DatabaseFileName);
        }

        /// <summary>
        /// Открывает соединение и включает контроль внешних ключей.
        /// Вызывающий код обязан освободить соединение (using).
        /// </summary>
        public static SqliteConnection OpenConnection()
        {
            string path = DatabasePath;
            if (!File.Exists(path))
            {
                throw new DatabaseUnavailableException(
                    "Файл базы данных не найден:" + Environment.NewLine + path + Environment.NewLine +
                    "Создайте базу командой SQL\\create_db.bat.");
            }

            try
            {
                SqliteConnection connection = new SqliteConnection(ConnectionString);
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA foreign_keys = ON;";
                    command.ExecuteNonQuery();
                }

                return connection;
            }
            catch (SqliteException exception)
            {
                throw new DatabaseUnavailableException(
                    "Не удалось подключиться к базе данных. Проверьте, что файл db\\repair.db не повреждён.",
                    exception);
            }
        }

        /// <summary>
        /// Проверяет логин и пароль по трём таблицам пользователей и определяет роль.
        /// </summary>
        public static AuthResult Authenticate(string login, string password)
        {
            using (SqliteConnection connection = OpenConnection())
            {
                UserRow admin = FindUser(connection, "ADMIN", login, password);
                if (admin != null)
                {
                    return AuthResult.Ok(new UserSession(admin.Id, admin.FullName, UserRole.Administrator));
                }

                UserRow specialist = FindSpecialist(connection, login, password);
                if (specialist != null)
                {
                    if (!specialist.IsActive)
                    {
                        return AuthResult.Fail("Учётная запись специалиста заблокирована. Обратитесь к администратору.");
                    }

                    return AuthResult.Ok(new UserSession(specialist.Id, specialist.FullName, UserRole.Specialist));
                }

                UserRow employee = FindUser(connection, "EMPLOYEE", login, password);
                if (employee != null)
                {
                    return AuthResult.Ok(new UserSession(employee.Id, employee.FullName, UserRole.Employee));
                }

                return AuthResult.Fail("Неверный логин или пароль.");
            }
        }

        /// <summary>
        /// Возвращает список заявок с расшифровкой справочных полей.
        /// При userId >= 0 — только заявки этого сотрудника,
        /// иначе (специалист/администратор) — все заявки.
        /// </summary>
        public static List<RequestListItem> GetRequests(int userId)
        {
            List<RequestListItem> requests = new List<RequestListItem>();

            using (SqliteConnection connection = OpenConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                string whereClause = userId >= 0 ? " WHERE r.employee_id = $userId " : " ";

                command.CommandText =
                    "SELECT r.id, e.full_name, et.name, r.problem_description, r.created_at, s.full_name, st.name " +
                    "FROM REQUEST r " +
                    "JOIN EMPLOYEE e ON e.id = r.employee_id " +
                    "JOIN EQUIPMENT_TYPE et ON et.id = r.equipment_type_id " +
                    "JOIN STATUS st ON st.id = r.status_id " +
                    "LEFT JOIN SPECIALIST s ON s.id = r.specialist_id " +
                    whereClause +
                    "ORDER BY r.created_at DESC, r.id DESC;";

                if (userId >= 0)
                {
                    command.Parameters.AddWithValue("$userId", userId);
                }

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new RequestListItem
                        {
                            Id = reader.GetInt32(0),
                            EmployeeName = reader.GetString(1),
                            EquipmentTypeName = reader.GetString(2),
                            ProblemDescription = reader.GetString(3),
                            CreatedAt = reader.GetString(4),
                            SpecialistName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            StatusName = reader.GetString(6)
                        });
                    }
                }
            }

            return requests;
        }

        // Имена таблиц передаются только из констант внутри этого класса.
        private static UserRow FindUser(SqliteConnection connection, string tableName, string login, string password)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT id, full_name FROM " + tableName +
                    " WHERE login = $login AND password = $password LIMIT 1;";
                command.Parameters.AddWithValue("$login", login);
                command.Parameters.AddWithValue("$password", password);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new UserRow
                    {
                        Id = reader.GetInt32(0),
                        FullName = reader.GetString(1),
                        IsActive = true
                    };
                }
            }
        }

        private static UserRow FindSpecialist(SqliteConnection connection, string login, string password)
        {
            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "SELECT id, full_name, is_active FROM SPECIALIST " +
                    "WHERE login = $login AND password = $password LIMIT 1;";
                command.Parameters.AddWithValue("$login", login);
                command.Parameters.AddWithValue("$password", password);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new UserRow
                    {
                        Id = reader.GetInt32(0),
                        FullName = reader.GetString(1),
                        IsActive = reader.GetInt32(2) == 1
                    };
                }
            }
        }

        private sealed class UserRow
        {
            public int Id;
            public string FullName;
            public bool IsActive;
        }

        private static readonly string[] RequiredTables =
        {
            "EMPLOYEE", "ADMIN", "SPECIALIST", "EQUIPMENT_TYPE", "STATUS", "REQUEST"
        };

        /// <summary>
        /// Создаёт резервную копию базы данных в указанный файл.
        /// Использует VACUUM INTO — SQLite сам делает согласованную копию даже на «живой» базе.
        /// </summary>
        public static void BackupDBToFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("Не указан путь для резервной копии.", nameof(filePath));
            }

            string destination = Path.GetFullPath(filePath);

            string directory = Path.GetDirectoryName(destination);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // VACUUM INTO не перезаписывает существующий файл — удаляем его заранее.
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            using (SqliteConnection connection = OpenConnection())
            using (SqliteCommand command = connection.CreateCommand())
            {
                // Путь подставляется литералом, поэтому экранируем одинарные кавычки.
                command.CommandText = "VACUUM INTO '" + destination.Replace("'", "''") + "';";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Заменяет текущую базу данных выбранным файлом резервной копии.
        /// Перед заменой сохраняет копию текущей базы рядом с ней (возвращает её путь).
        /// </summary>
        public static string RestoreDBFromFile(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                throw new ArgumentException("Не указан файл резервной копии.", nameof(sourceFilePath));
            }

            string source = Path.GetFullPath(sourceFilePath);
            string target = Path.GetFullPath(DatabasePath);

            if (!File.Exists(source))
            {
                throw new FileNotFoundException("Файл резервной копии не найден.", source);
            }

            if (string.Equals(source, target, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Выбранный файл уже является текущей базой данных.");
            }

            EnsureValidDatabase(source);

            // Отпускаем соединения из пула, иначе файл базы останется заблокированным.
            SqliteConnection.ClearAllPools();

            string targetDirectory = Path.GetDirectoryName(target);
            if (!string.IsNullOrEmpty(targetDirectory) && !Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string backupPath = null;
            if (File.Exists(target))
            {
                backupPath = target + ".before-restore-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".bak";
                File.Copy(target, backupPath, true);
            }

            DeleteSidecarFiles(target);
            File.Copy(source, target, true);

            return backupPath;
        }

        /// <summary>
        /// Проверяет, что файл — корректная база SQLite с ожидаемым набором таблиц.
        /// </summary>
        private static void EnsureValidDatabase(string filePath)
        {
            try
            {
                SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder
                {
                    DataSource = filePath,
                    Mode = SqliteOpenMode.ReadOnly
                };

                using (SqliteConnection connection = new SqliteConnection(builder.ToString()))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "PRAGMA integrity_check;";
                        string result = Convert.ToString(command.ExecuteScalar());
                        if (!string.Equals(result, "ok", StringComparison.OrdinalIgnoreCase))
                        {
                            throw new DatabaseUnavailableException(
                                "Файл повреждён: проверка целостности базы данных не пройдена.");
                        }
                    }

                    HashSet<string> tables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table';";
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tables.Add(reader.GetString(0));
                            }
                        }
                    }

                    foreach (string tableName in RequiredTables)
                    {
                        if (!tables.Contains(tableName))
                        {
                            throw new DatabaseUnavailableException(
                                "В выбранном файле нет таблицы " + tableName + "." + Environment.NewLine +
                                "Это не база данных системы учёта заявок.");
                        }
                    }
                }
            }
            catch (SqliteException exception)
            {
                throw new DatabaseUnavailableException(
                    "Выбранный файл не является корректной базой данных SQLite.", exception);
            }
        }

        /// <summary>
        /// Удаляет служебные файлы SQLite (-wal, -shm, -journal), оставшиеся от старой базы.
        /// </summary>
        private static void DeleteSidecarFiles(string databasePath)
        {
            string[] suffixes = { "-wal", "-shm", "-journal" };

            foreach (string suffix in suffixes)
            {
                string sidecar = databasePath + suffix;
                if (File.Exists(sidecar))
                {
                    File.Delete(sidecar);
                }
            }
        }
    }
}
