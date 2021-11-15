using FluentNHibernate.Mapping;
using Sanri.Models;

namespace Sanri.Maps
{
    public class ProductMap: ClassMap<ProductModel>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
        }
    }
}