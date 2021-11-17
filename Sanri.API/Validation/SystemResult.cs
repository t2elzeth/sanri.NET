using System;

namespace Sanri.API.Validation
{
    public class SystemResult<TResult>
    {
        public bool IsFailure => _error is not null;

        private readonly SystemError? _error;
        public SystemError Error => _error ?? throw new InvalidOperationException("No error");

        private readonly TResult? _value;
        public TResult Value => _value ?? throw new InvalidOperationException("Cannot get value of error result");

        public SystemResult(TResult? value, SystemError? error)
        {
            _value = value;
            _error = error;
        }

        public static implicit operator SystemResult<TResult>(TResult result)
        {
            return new SystemResult<TResult>(value: result,
                                             error: null);
        }

        public static implicit operator SystemResult<TResult>(SystemError error)
        {
            return new SystemResult<TResult>(value: default,
                                             error: error);
        }
    }

    public class SystemResult : SystemResult<object>
    {
        public static readonly SystemResult Success = new(value: new object(), error: null);

        public SystemResult(object? value, SystemError? error)
            : base(value, error)
        {
        }

        public static implicit operator SystemResult(SystemError error)
        {
            return new SystemResult(value: default,
                                    error: error);
        }
    }
}