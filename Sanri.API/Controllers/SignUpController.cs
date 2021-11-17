using System;
using Microsoft.AspNetCore.Mvc;
using Sanri.API.DTOs;
using Sanri.Application;

namespace Sanri.API.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignUpController
    {
        private readonly CreateUserHandler _createUserHandler;

        public SignUpController(CreateUserHandler createUserHandler)
        {
            _createUserHandler = createUserHandler;
        }
        
        [HttpPost]
        public UserDTO Post([FromBody] SignUpDTO payload)
        {
            var user = _createUserHandler.Execute();

            return new UserDTO
            {
                Id       = user.Id,
                Username = user.Username
            };
        }
    }
}