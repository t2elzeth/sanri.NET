using System;
using System.Threading.Tasks;
using Commons.Nh;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;

namespace Sanri.Application.Nh
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NhSessionAttribute : Attribute
    {
    }

    public class NhSessionAttributeActionFilter : IAsyncActionFilter
    {
        private readonly ISessionFactory _sessionFactory;

        public NhSessionAttributeActionFilter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                 ActionExecutionDelegate next)
        {
            if (!context.ActionDescriptor.IsControllerAction())
            {
                await next();
                return;
            }

            var attribute = AttributeProvider<NhSessionAttribute>.FirstOrDefault(context.ActionDescriptor.GetMethodInfo());

            if (attribute == null)
            {
                await next();
                return;
            }

            using (NhDatabaseSession.Bind(_sessionFactory))
            {
                await next();
            }
        }
    }
}