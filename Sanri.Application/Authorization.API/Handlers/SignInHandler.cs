using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sanri.Application.Authorization.API.Repositories;
using Sanri.Core.Models;
using Sanri.System;

namespace Sanri.Application.Authorization.API.Handlers
{
    public class SignInCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SignInResult
    {
        public string AccessToken { get; set; }

        public static implicit operator SignInResult(string token)
        {
            return new SignInResult
            {
                AccessToken = token
            };
        }
    }

    public class SignInHandlerOptions
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
    
    public class SignInHandler
    {
        private readonly IOptions<SignInHandlerOptions> _options;
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public SignInHandler(IOptions<SignInHandlerOptions> options,
                             UserRepository userRepository, 
                             PasswordHasher<User> passwordHasher)
        {
            _options   = options;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<SystemResult<SignInResult>> Handle(SignInCommand command)
        {
            var user      = await _userRepository.GetSingle(command.Username);
            var isCorrect = VerifyPassword(user, user.Password, command.Password);

            if (!isCorrect)
                return SystemError.InvalidPassword;

            return Generate(user);
        }

        private bool VerifyPassword(User user, string hashedPassword, string givenPassword)
        {
            var isCorrect = _passwordHasher.VerifyHashedPassword(user, hashedPassword, givenPassword);

            return isCorrect == PasswordVerificationResult.Success;
        }

        private SignInResult Generate(User user)
        {
            var options = _options.Value;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
            };

            var token = new JwtSecurityToken(options.Issuer,
                                             options.Audience,
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static bool TryGetValue(string param, [MaybeNullWhen(false)]out string result)
        {
            if (param == "ok")
            {
                result = "ok";
                return true;
            }

            result = null;
            return false;
        }
    }
}