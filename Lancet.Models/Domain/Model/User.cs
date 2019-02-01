using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Хэш пароля
        /// </summary>
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// Соль
        /// </summary>
        public byte[] PasswordSalt { get; set; }
    }
}
