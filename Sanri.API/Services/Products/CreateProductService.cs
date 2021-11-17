using NHibernate;
using Sanri.API.Models;
using Sanri.API.Validation;

namespace Sanri.API.Services.Products
{
    public class CreateProductService
    {
        private readonly ISessionFactory _sessionFactory;

        public CreateProductService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public SystemResult<Product> Execute(ProductCreate productData)
        {
            var priceResult = Price.Create(productData.Price);
            if (priceResult.IsFailure)
                return new SystemError("price", priceResult.Error);

            using var session     = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            var product = new Product
            {
                Name  = productData.Name,
                Price = productData.Price
            };

            session.SaveOrUpdate(product);

            transaction.Commit();
            // transaction.Rollback();

            return product;
        }
    }
}