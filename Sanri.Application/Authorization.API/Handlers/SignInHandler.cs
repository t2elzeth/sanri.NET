using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sanri.Application.Authorization.API.Repositories;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Handlers
{
    public class SignInCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class SignInResult
    {
        public string AccessToken { get; set; }
    }

    public class SignInHandler
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;

        public SignInHandler(UserRepository userRepository, PasswordHasher<User> passwordHasher, IConfiguration config)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _config    = config;
        }

        public async Task<SignInResult> Handle(SignInCommand command)
        {
            var user      = await _userRepository.GetSingle(command.Username);
            var isCorrect = VerifyPassword(user, user.Password, command.Password);

            if (isCorrect)
            {
                // var user = Authenticate(command);
                var token = Generate(user);
                var result = new SignInResult
                {
                    AccessToken = token,
                };
                return result;
            }

            return new SignInResult
            {
                AccessToken = "disallowed"
            };
        }

        private bool VerifyPassword(User user, string hashedPassword, string givenPassword)
        {
            var isCorrect = _passwordHasher.VerifyHashedPassword(user, hashedPassword, givenPassword);

            return isCorrect == PasswordVerificationResult.Success;
        }
        
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SignInCommand Authenticate(SignInCommand userLogin)
        {
            return userLogin;
        }
    }
}