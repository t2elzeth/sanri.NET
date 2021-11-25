using FluentValidation;
using NHibernate;
using Sanri.API.Validation.CustomValidators;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Application.Authorization.API.Repositories;

namespace Sanri.API.Authorization.API.DTOs
{
    public class SignInRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}