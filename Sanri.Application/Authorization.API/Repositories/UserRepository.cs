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
            var transaction     = nhSession.BeginTransaction();

            await nhSession.SaveOrUpdateAsync(user);

            transaction.Commit();

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

        public async Task<User> GetSingle(string username)
        {
            const string sql = @"
select id, 
       username,
       password
from public.users
where username = @username
";
            var parameters = new
            {
                username
            };

            var databaseSession = NhDatabaseSession.Current;
            var connection      = databaseSession.Connection;

            var user = await connection.QuerySingleAsync<User>(sql, parameters);

            return user;
        }
    }
}