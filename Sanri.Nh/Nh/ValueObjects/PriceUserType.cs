// using System;
// using NHibernate;
// using NHibernate.Type;
// using Sanri.API.Models;
//
// namespace Sanri.API.Nh
// {
//     public sealed class PriceUserType : SingleValueObjectType<Price>
//     {
//         protected override NullableType PrimitiveType => NHibernateUtil.Decimal;
//
//         protected override Price Create(object value)
//         {
//             var price = Convert.ToDecimal(value);
//             return Price.Create(price).Value;
//         }
//
//         protected override object GetValue(Price price)
//         {
//             return price.Value;
//         }
//     }
// }