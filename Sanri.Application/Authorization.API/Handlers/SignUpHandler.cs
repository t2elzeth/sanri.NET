using System.Threading.Tasks;
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

        public SignUpHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(SignUpCommand command)
        {
            var user = new User
            {
                Username = command.Username,
                Password = command.Password
            };

            return await _userRepository.Save(user);
        }
    }
}