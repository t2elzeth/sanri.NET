using Microsoft.AspNetCore.Identity;
using Sanri.Models;

namespace Sanri.Services
{
    public class PasswordHashingService
    {
        private readonly PasswordHasher<User> _hasher;

        public PasswordHashingService()
        {
            _hasher = new PasswordHasher<User>();
        }

        public string Generate(User user, string providedPassword)
        {
            return _hasher.HashPassword(user, providedPassword);
        }

        public bool Validate(User user, string hashedPassword, string providedPassword)
        {
            var passwordVerificationResult = _hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);

            switch (passwordVerificationResult)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return true;
                default:
                    return false;
            }
        }
    }
}