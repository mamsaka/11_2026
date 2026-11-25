using System;

namespace RepairRequestor.services
{
    /// <summary>
    /// Роль пользователя в системе.
    /// </summary>
    public enum UserRole
    {
        Employee = 1,
        Specialist = 2,
        Administrator = 3
    }

    /// <summary>
    /// Авторизованный пользователь, данные которого используются на главном экране.
    /// </summary>
    public sealed class UserSession
    {
        public UserSession(int id, string fullName, UserRole role)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Идентификатор пользователя должен быть положительным.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("ФИО пользователя не может быть пустым.", nameof(fullName));
            }

            Id = id;
            FullName = fullName.Trim();
            Role = role;
        }

        public int Id { get; }

        public string FullName { get; }

        public UserRole Role { get; }

        public string RoleDisplayName
        {
            get
            {
                switch (Role)
                {
                    case UserRole.Administrator:
                        return "Администратор";
                    case UserRole.Specialist:
                        return "Специалист";
                    default:
                        return "Сотрудник";
                }
            }
        }
    }

    /// <summary>
    /// Результат попытки входа: либо сессия пользователя, либо текст ошибки для формы.
    /// </summary>
    public sealed class AuthResult
    {
        private AuthResult(bool success, UserSession user, string errorMessage)
        {
            Success = success;
            User = user;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; }

        public UserSession User { get; }

        public string ErrorMessage { get; }

        public static AuthResult Ok(UserSession user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new AuthResult(true, user, null);
        }

        public static AuthResult Fail(string errorMessage)
        {
            return new AuthResult(false, null, errorMessage);
        }
    }
}
