using System.Threading.Tasks;
using Sanri.Application.Authorization.API.Repositories;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Handlers
{
    public class CreateUserCommand
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
    
    public class CreateUserHandler
    {
        private readonly UserRepository _userRepository;

        public CreateUserHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand command)
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