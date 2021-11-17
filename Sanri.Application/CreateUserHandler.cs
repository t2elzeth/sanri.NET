using Sanri.Application.Models;

namespace Sanri.Application
{
    public class CreateUserHandler
    {
        public User Execute()
        {
            return new User
            {
                Username = "t2elzeth",
                Password = "admin12345"
            };
        }
    }
}