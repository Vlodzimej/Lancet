using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Service.Abstract
{
    public partial interface ILancetService
    {
        object AuthenticateUser(UserDto userDto);
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(Guid id);
        User CreateUser(UserDto userDto);
        void UpdateUser(Guid id, UserDto userDto, string password = null);
        void DeleteUser(Guid id);
    }
}
