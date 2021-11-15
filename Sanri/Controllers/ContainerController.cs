using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Sanri.Models;

namespace Sanri.Controllers
{
    [ApiController]
    [Route("containers")]
    public class ContainerController : Controller
    {
        [HttpGet]
        public IList<ContainerModel> Get([FromServices] ISessionFactory sessionFactory)
        {
            using var session = sessionFactory.OpenSession();
            var containers = session.Query<ContainerModel>().ToList();
            
            return containers.Select(c => new ContainerModel()
            {
                Id = c.Id,
                Name = c.Name,
                DateOfSending = c.DateOfSending,
                Client = new UserModel()
                {
                    Id = c.Client.Id,
                    FullName = c.Client.FullName
                }
            }).ToArray();
        }
    }
}