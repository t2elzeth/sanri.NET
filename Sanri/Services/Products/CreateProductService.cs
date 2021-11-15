using System;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using Sanri.Models;

namespace Sanri.Services.Products
{
    public class CreateProductService
    {
        private readonly ISessionFactory _sessionFactory;

        public CreateProductService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Product Execute(ProductCreate productData)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var product = new Product()
            {
                Name = productData.Name,
                Price = productData.Price
            };
            
            session.SaveOrUpdate(product);
            
            transaction.Commit();
            // transaction.Rollback();

            return product;
        }
    }
}