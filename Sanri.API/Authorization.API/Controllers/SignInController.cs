using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SignInController> _logger;
        private readonly IMapper _mapper;
        private readonly SignInHandler _signInHandler;

        public SignInController(ILogger<SignInController> logger,
                                IMapper mapper, SignInHandler signInHandler)
        {
            _logger   = logger;
            _mapper        = mapper;
            _signInHandler = signInHandler;
        }

        [HttpPost, NhSession]
        public async Task<ActionResult<SignInResult>> Post(SignInRequest request)
        {
            _logger.LogDebug("Enter Post Method. Request {@Request}", request);
            
            var command = _mapper.Map<SignInCommand>(request);
            var result = await _signInHandler.Handle(command);

            return Result(result);
        }
        
        private ActionResult<T> Result<T>(SystemResult<T> result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return result.Value;
        }
    }
}