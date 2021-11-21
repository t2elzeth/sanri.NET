using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Infrastructure.Nh;

namespace Sanri.API.Authorization.API.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignUpController
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly IMapper _mapper;

        public SignUpController(CreateUserHandler createUserHandler, IMapper mapper)
        {
            _createUserHandler = createUserHandler;
            _mapper       = mapper;
        }

        [HttpPost, NhSession]
        public async Task<ActionResult<UserResponse>> Post([FromBody] SignUpRequest request)
        {
            var command = _mapper.Map<CreateUserCommand>(request);
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