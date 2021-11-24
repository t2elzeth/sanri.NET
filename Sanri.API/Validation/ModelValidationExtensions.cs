using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sanri.System;

namespace Sanri.API.Validation
{
    public static class ModelValidationExtensions
    {
        public static IMvcCoreBuilder UseCustomModelValidation(this IMvcCoreBuilder builder)
        {
            return builder.ConfigureApiBehaviorOptions(options => //
            {
                options.InvalidModelStateResponseFactory = CustomErrorResponse;
            });
        }

        private static BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            var errorResult = new SystemError();

            var modelState = actionContext.ModelState;
            var (nameError, rootError) = modelState.First();
            var modelError = rootError.Errors.First();
            
            errorResult.SetError(nameError, modelError.ErrorMessage);

            return new BadRequestObjectResult(errorResult);
        }
    }
}