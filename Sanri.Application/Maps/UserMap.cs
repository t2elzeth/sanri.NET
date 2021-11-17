using FluentNHibernate.Mapping;
using Sanri.Application.Models;

namespace Sanri.Application.Maps
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Schema("public");
            
            Id(x => x.Id);
            Map(x => x.Username);
        }
    }
}