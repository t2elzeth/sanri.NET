using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sanri.Application.Authorization.API.Repositories;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Handlers
{
    public class SignInCommand
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class SignInHandler
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public SignInHandler(UserRepository userRepository, PasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(SignInCommand command)
        {
            var user      = await _userRepository.GetSingle(command.Username);
            var isCorrect = VerifyPassword(user, user.Password, command.Password);

            return user.Username;
        }

        private bool VerifyPassword(User user, string hashedPassword, string givenPassword)
        {
            var isCorrect = _passwordHasher.VerifyHashedPassword(user, hashedPassword, givenPassword);

            return isCorrect == PasswordVerificationResult.Success;
        }
    }
}