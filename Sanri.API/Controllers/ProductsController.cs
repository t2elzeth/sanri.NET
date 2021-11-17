using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Sanri.API.DTOs;
using Sanri.API.Models;
using Sanri.API.Services.Products;
using Sanri.API.Validation;

namespace Sanri.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly CreateProductService _createProductService;

        public ProductsController(ISessionFactory sessionFactory,
                                  CreateProductService createProductService)
        {
            _sessionFactory       = sessionFactory;
            _createProductService = createProductService;
        }

        [HttpGet]
        public IList<ProductDTO> Get()
        {
            using var session = _sessionFactory.OpenSession();

            var products = session.Query<Product>().ToList();

            return products.Select(product => new ProductDTO
            {
                Id    = product.Id,
                Name  = product.Name,
                Price = product.Price.Value
            }).ToArray();
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] ProductCreate productData)
        {
            var productResult = _createProductService.Execute(productData);
            
            return Result(productResult);
        }

        private ActionResult<T> Result<T>(SystemResult<T> result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return result.Value;
        }
    }
}