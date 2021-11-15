using FluentNHibernate.Mapping;
using Sanri.Models;

namespace Sanri.Maps
{
    public class UserMap: ClassMap<UserModel>
    {
        public UserMap()
        {
            Schema("public");
            
            Id(x => x.Id);
            Map(x => x.FullName);
        }
    }
}