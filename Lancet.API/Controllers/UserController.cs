using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lancet.Models.Domain.Dtos;
using Lancet.Service.Abstract;
using Lancet.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lancet.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/User")]
    public class UsersController : ControllerBase
    {
        private ILancetService _coldWarService;

        public UsersController(ILancetService coldWarService)
        {
            _coldWarService = coldWarService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            try
            {
                var result = _coldWarService.AuthenticateUser(userDto);
                return new ObjectResult(result);
            }
            catch(AppException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            try
            {
                // save 
                _coldWarService.CreateUser(userDto);
                return new OkResult();
            }
            catch (AppException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _coldWarService.GetAllUsers();
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _coldWarService.GetUserById(id);
            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UserDto userDto)
        {
            try
            {
                // save 
                _coldWarService.UpdateUser(id, userDto);
                return new OkResult();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _coldWarService.DeleteUser(id);
                return new OkResult();
            }
            catch(AppException ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}