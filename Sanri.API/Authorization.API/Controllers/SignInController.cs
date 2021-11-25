using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Nh;
using SignInResult = Sanri.Application.Authorization.API.Handlers.SignInResult;

namespace Sanri.API.Authorization.API.Controllers
{
    [ApiController]
    [Route("signin")]
    public class SignInController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SignInHandler _signInHandler;

        public SignInController(IMapper mapper, SignInHandler signInHandler)
        {
            _mapper        = mapper;
            _signInHandler = signInHandler;
        }

        [HttpPost, NhSession]
        public async Task<ActionResult<SignInResult>> Post(SignInRequest request)
        {
            var command = _mapper.Map<SignInCommand>(request);
            return await _signInHandler.Handle(command);
        }
    }
}