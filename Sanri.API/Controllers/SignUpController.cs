using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sanri.API.DTOs;
using Sanri.Application;
using Sanri.Application.Nh;

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

        [HttpPost, NhSession]
        public async Task<ActionResult<UserResponse>> Post([FromBody] SignUpRequest request)
        {
            var command = new CreateUserCommand
            {
                Username = request.Username,
                Password = request.Password
            };

            var user = await _createUserHandler.Handle(command);

            var response = new UserResponse
            {
                Id       = user.Id,
                Username = user.Username
            };

            return response;
        }
    }
}