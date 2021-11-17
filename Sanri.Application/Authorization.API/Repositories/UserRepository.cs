using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Nh;
using Dapper;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Repositories
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

        public async Task<IList<User>> GetAll()
        {
            const string sql = @"
select username 
from public.users;
";
            // var parameters = new
            // {
            //     category
            // };

            var databaseSession = NhDatabaseSession.Current;
            var connection      = databaseSession.Connection;

            var rows = await connection.QueryAsync<User>(sql);

            return rows.ToList();
        }
    }
}