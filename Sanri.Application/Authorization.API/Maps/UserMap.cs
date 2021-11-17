using FluentNHibernate.Mapping;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("public");

            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Password);
        }
    }
}