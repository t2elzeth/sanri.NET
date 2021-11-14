using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NHibernate.Context;
using Sanri.Models;

namespace Sanri.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController
    {
        [HttpGet]
        public IList<Product> Get()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            ConnectionStringsManager.ReadFromConfiguration(configuration);

            var sessionFactory = new SessionFactoryBuilder()
                .CurrentSessionContext<AsyncLocalSessionContext>()
                .AddFluentMappingsFrom("Sanri")
                .Build();

            using var session = sessionFactory.OpenSession();
            var products = session.Query<Product>().ToList();

            return products.Select(product => new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToArray();
        }

        [HttpPost]
        public Product Post([FromBody] Product productData)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            ConnectionStringsManager.ReadFromConfiguration(configuration);

            var sessionFactory = new SessionFactoryBuilder()
                .CurrentSessionContext<AsyncLocalSessionContext>()
                .AddFluentMappingsFrom("Sanri")
                .Build();

            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var product = new Product()
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