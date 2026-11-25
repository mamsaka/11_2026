using System;
using Microsoft.Data.Sqlite;

namespace RepairRequestor.services
{
    /// <summary>
    /// Бэкенд страницы авторизации: валидация введённых данных и обращение к базе.
    /// </summary>
    internal static class AuthService
    {
        public const int MinLoginLength = 3;
        public const int MaxLoginLength = 50;
        public const int MaxPasswordLength = 100;

        public static AuthResult Login(string login, string password)
        {
            login = (login ?? string.Empty).Trim();
            password = password ?? string.Empty;

            if (login.Length == 0)
            {
                return AuthResult.Fail("Введите логин.");
            }

            if (password.Length == 0)
            {
                return AuthResult.Fail("Введите пароль.");
            }

            if (login.Length < MinLoginLength)
            {
                return AuthResult.Fail("Логин должен содержать не менее " + MinLoginLength + " символов.");
            }

            if (login.Length > MaxLoginLength)
            {
                return AuthResult.Fail("Логин не должен превышать " + MaxLoginLength + " символов.");
            }

            if (password.Length > MaxPasswordLength)
            {
                return AuthResult.Fail("Пароль не должен превышать " + MaxPasswordLength + " символов.");
            }

            try
            {
                return DatabaseHandler.Authenticate(login, password);
            }
            catch (DatabaseUnavailableException exception)
            {
                return AuthResult.Fail(exception.Message);
            }
            catch (SqliteException)
            {
                return AuthResult.Fail(
                    "Ошибка при обращении к базе данных. Проверьте целостность файла db\\repair.db.");
            }
            catch (Exception)
            {
                return AuthResult.Fail("Не удалось выполнить вход. Попробуйте ещё раз.");
            }
        }
    }
}
