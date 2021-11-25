using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Nh;

namespace Sanri.API.Authorization.API.Controllers
{
    [ApiController]
    [Route("signin")]
    public class SignInController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SignInHandler _signInHandler;
        private readonly IConfiguration _config;

        public SignInController(IMapper mapper, SignInHandler signInHandler, IConfiguration config)
        {
            _mapper        = mapper;
            _signInHandler = signInHandler;
            _config        = config;
        }

        [HttpPost, NhSession]
        public async Task<ActionResult<string>> Post(SignInRequest request)
        {
            // var command = _mapper.Map<SignInCommand>(request);
            // return await _signInHandler.Handle(command);
            var user = Authenticate(request);

            var token = Generate(user);
            return Ok(token);
        }

        private string Generate(SignInRequest user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                // new Claim(ClaimTypes.Email, user.EmailAddress),
                // new Claim(ClaimTypes.GivenName, user.GivenName),
                // new Claim(ClaimTypes.Surname, user.Surname),
                // new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SignInRequest Authenticate(SignInRequest userLogin)
        {
            return userLogin;
        }
    }
}