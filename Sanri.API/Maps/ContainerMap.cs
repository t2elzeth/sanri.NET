using FluentNHibernate.Mapping;
using Sanri.API.Models;

namespace Sanri.API.Maps
{
    public class ContainerMap : ClassMap<Container>
    {
        public ContainerMap()
        {
            Schema("public");
            
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.DateOfSending); //date_of_sending
            References(x => x.Client);
        }
    }
}