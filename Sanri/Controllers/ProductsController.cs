using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Sanri.Models;
using Sanri.Services;
using Sanri.Services.Products;

namespace Sanri.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController: Controller
    {
        private readonly ISessionFactory _sessionFactory;

        public ProductsController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        [HttpGet]
        public IList<Product> Get()
        {
            using var session = _sessionFactory.OpenSession();
            var products = session.Query<Product>().ToList();

            return products.Select(product => new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }).ToArray();
        }

        [HttpPost]
        public Product Post([FromBody] ProductCreate productData, [FromServices] CreateProductService productService)
        {
            return productService.Execute(productData);
        }
    }
}