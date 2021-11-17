using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using Sanri.API.Models;

namespace Sanri.API.Nh
{
    public class UserTypesConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.PropertyType == typeof(Price)) 
                instance.CustomType<PriceUserType>();      
        }
    }
}