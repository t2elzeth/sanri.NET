using System;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Sanri.API.DTOs;
using Sanri.API.Models;

namespace Sanri.API.Controllers
{
    [ApiController]
    [Route("signup")]
    public class SignUpController
    {
        private readonly ISessionFactory _sessionFactory;

        public SignUpController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        [HttpPost]
        public UserDTO Post([FromBody] SignUpDTO payload)
        {

            var session     = _sessionFactory.OpenSession();
            var transaction = session.BeginTransaction();

            var user = new User
            {
                Username = "t2elzeth",
                Password = "admin12345"
            };
            
            session.SaveOrUpdate(user);
            
            transaction.Commit();

            return new UserDTO
            {
                Id       = user.Id,
                Username = user.Username
            };
        }
    }
}