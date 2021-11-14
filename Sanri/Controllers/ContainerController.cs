using System;
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
    [Route("containers")]
    public class ContainerController : Controller
    {
        [HttpGet]
        public IList<Container> Get()
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
            var containers = session.Query<Container>().ToList();
            
            return containers.Select(c => new Container()
            {
                Id = c.Id,
                Name = c.Name,
                DateOfSending = c.DateOfSending,
                Client = new User()
                {
                    Id = c.Client.Id,
                    FullName = c.Client.FullName
                }
            }).ToArray();
        }
    }
}