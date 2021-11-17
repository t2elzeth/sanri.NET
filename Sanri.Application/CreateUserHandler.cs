using Sanri.Application.Models;

namespace Sanri.Application
{
    public class CreateUserHandler
    {
        public User Execute()
        {
            return new User
            {
                Id       = 2,
                Username = "t2elzeth"
            };
        }
    }
}