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
        private readonly SignUpHandler _signUpHandler;
        private readonly IMapper _mapper;

        public SignUpController(SignUpHandler signUpHandler, IMapper mapper)
        {
            _signUpHandler = signUpHandler;
            _mapper       = mapper;
        }

        [HttpPost, NhSession]
        public async Task<ActionResult<UserResponse>> Post([FromBody] SignUpRequest request)
        {
            var command = _mapper.Map<SignUpCommand>(request);
            var user = await _signUpHandler.Handle(command);

            var response = new UserResponse
            {
                Id       = user.Id,
                Username = user.Username
            };

            return response;
        }
    }
}