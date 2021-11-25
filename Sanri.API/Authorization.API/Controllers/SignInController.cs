using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Nh;
using Sanri.System;
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
            var result = await _signInHandler.Handle(command);

            return Result<SignInResult>(result);
        }
        
        private ActionResult<T> Result<T>(SystemResult<T> result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return result.Value;
        }
    }
}