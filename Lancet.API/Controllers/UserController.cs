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
        private ILancetService _lancetService;

        public UsersController(ILancetService lancetService)
        {
            _lancetService = lancetService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            try
            {
                var result = _lancetService.AuthenticateUser(userDto);
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
                _lancetService.CreateUser(userDto);
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
            var result = _lancetService.GetAllUsers();
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _lancetService.GetUserById(id);
            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody]UserDto userDto)
        {
            try
            {
                // save 
                _lancetService.UpdateUser(id, userDto);
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
                _lancetService.DeleteUser(id);
                return new OkResult();
            }
            catch(AppException ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}