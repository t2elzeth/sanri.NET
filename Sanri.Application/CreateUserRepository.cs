using System.Threading.Tasks;
using Commons.Nh;
using Sanri.API.Models;

namespace Sanri.Application
{
    public class UserRepository
    {
        // TODO: Save or create
        public async Task<User> Save(User user)
        {
            var databaseSession = NhDatabaseSession.Current;
            var nhSession       = databaseSession.Session;

            await nhSession.SaveOrUpdateAsync(user);

            return user;
        }
    }
}