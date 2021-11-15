using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Sanri.Models;

namespace Sanri.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController
    {
        private readonly ISessionFactory _sessionFactory;

        public ProductsController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        [HttpGet]
        public IList<ProductModel> Get()
        {
            using var session = _sessionFactory.OpenSession();
            var products = session.Query<ProductModel>().ToList();

            return products.Select(product => new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToArray();
        }

        [HttpPost]
        public ProductModel Post([FromBody] ProductModel productData)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var product = new ProductModel()
            {
                Name = productData.Name,
                Price = productData.Price
            };
            
            session.SaveOrUpdate(product);
            transaction.Commit();

            return product;
        }
    }
}