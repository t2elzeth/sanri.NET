using FluentNHibernate.Mapping;
using Sanri.Models;

namespace Sanri.Maps
{
    public class ContainerMap : ClassMap<Container>
    {
        public ContainerMap()
        {
            Schema("public");
            
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.DateOfSending);
            References(x => x.Client);
        }
    }
}