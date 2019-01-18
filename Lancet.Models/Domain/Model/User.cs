using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
