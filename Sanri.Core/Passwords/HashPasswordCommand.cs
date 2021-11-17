using System;

namespace Sanri.Core
{
    public class HashPasswordCommand
    {
        private readonly PasswordHasher<User> _hasher;

        public HashPasswordCommand()
        {
            _hasher = new PasswordHasher<User>();
        }
    }
}