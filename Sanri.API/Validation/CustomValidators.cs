using System;
using CSharpFunctionalExtensions;
using FluentValidation;

namespace Sanri.API.Validation
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, TProperty> MustBeValueObject<T, TValueObject, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
                                                                                                      Func<TProperty, Result<TValueObject, SystemError>> factoryMethod)
        {
            return (IRuleBuilderOptions<T, TProperty>) ruleBuilder.Custom((value, context) =>
            {
                Result<TValueObject, SystemError> result = factoryMethod(value!);

                if (result.IsFailure)
                {
                    context.AddFailure(result.Error.ToString());
                }
            });
        }

        public static IRuleBuilderOptions<T, TProperty> MustBeValueObject<T, TValueObject, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder,
                                                                                                      Func<TProperty, Result<TValueObject, string>> factoryMethod)
        {
            return (IRuleBuilderOptions<T, TProperty>) ruleBuilder.Custom((value, context) =>
            {
                Result<TValueObject, string> result = factoryMethod(value!);

                if (result.IsFailure)
                {
                    context.AddFailure(result.Error);
                }
            });
        }
    }
}