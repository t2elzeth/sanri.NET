using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sanri.Application.Authorization.API.Repositories;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Handlers
{
    public class SignUpCommand
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }

    public class SignUpHandler
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public SignUpHandler(UserRepository userRepository, PasswordHasher<User> passwordHasher)
        {
            _userRepository      = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Handle(SignUpCommand command)
        {
            var user = new User
            {
                Username = command.Username,
            };
            user.Password = HashPassword(user, command.Password);

            return await _userRepository.Save(user);
        }

        private string HashPassword(User user, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, password);
            return hashedPassword;
        }
    }
}