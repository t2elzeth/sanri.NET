using CSharpFunctionalExtensions;

namespace Sanri.API.Models
{
    public class Price : ValueObject<Price>
    {
        public decimal Value { get; }

        private Price(decimal value)
        {
            Value = value;
        }

        protected override bool EqualsCore(Price other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static Result<Price, string> Create(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return Result.Failure<Price, string>("Price is null");

            if (!decimal.TryParse(value, out var price))
                return Result.Failure<Price, string>("Enter value");

            return Create(price);
        }

        public static Result<Price, string> Create(decimal price)
        {
            if (price < 0.01m)
                return Result.Failure<Price, string>("Price must be greater than 0.01");

            return new Price(price);
        }

        public static implicit operator Price(decimal value)
        {
            return Create(value).Value;
        }
    }
}