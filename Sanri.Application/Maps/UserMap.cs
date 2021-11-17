using FluentNHibernate.Mapping;
using Sanri.API.Models;

namespace Sanri.Application.Maps
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