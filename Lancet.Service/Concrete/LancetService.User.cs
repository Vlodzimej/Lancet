using Lancet.Models.Domain.Model;
using Lancet.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Lancet.Service.Helpers;
using Lancet.Models.Domain.Dtos;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;
using System.Linq;

namespace Lancet.Service.Concrete
{
    public partial class LancetService : ILancetService
    {
        public object AuthenticateUser(UserDto userDto)
        {
            var appSettings = _configuration.GetSection("AppSettings");
            var user = Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                throw new AppException("User not found");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.GetValue<string>("Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return new
            {
                user.Id,
                user.Username,
                user.FirstName,
                user.LastName,
                Token = tokenString
            };
        }
        private User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _unitOfWork.UserRepository.Get(x => x.Username == username).FirstOrDefault();

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {

            var users = _unitOfWork.UserRepository.Get();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return userDtos;
        }

        public UserDto GetUserById(Guid id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public User CreateUser(UserDto userDto)
        {
            if(userDto == null)
                throw new AppException("Wrong user data");

            var user = Mapper.Map<User>(userDto);
            user.Id = Guid.NewGuid();
            // validation
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException("Password is required");

            if (_unitOfWork.UserRepository.Get(x => x.Username == user.Username).GetEnumerator().Current != null)
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.Save();

            return user;
        }

        public void UpdateUser(Guid id, UserDto userDto, string password = null)
        {
            // map dto to entity and set id
            var userParam = _mapper.Map<User>(userDto);
            userParam.Id = id;

            var user = _unitOfWork.UserRepository.GetByID(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                if (_unitOfWork.UserRepository.Get(x => x.Username == user.Username).GetEnumerator().Current != null)
                    throw new AppException("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(Guid id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);
            if (user != null)
            {
                _unitOfWork.UserRepository.Remove(user);
                _unitOfWork.Save();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
