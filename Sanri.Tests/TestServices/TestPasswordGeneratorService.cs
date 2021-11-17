using NUnit.Framework;
using Sanri.API.Models;
using Sanri.API.Services;

namespace Sanri.Tests.TestServices
{
    public class TestPasswordGeneratorService
    {
        private PasswordHashingService _service;
        private User _user;
        private string _providedPassword;
        private string _invalidPassword;

        [SetUp]
        public void Setup()
        {
            _service = new PasswordHashingService();
            _user = new User
            {
                Id = 1,
                FullName = AppFaker.User.FullName()
            };
            _providedPassword = AppFaker.User.Password();
            _invalidPassword = AppFaker.User.Password();
        }

        [Test]
        public void TestGenerateHash()
        {
            string hash = _service.Generate(_user, _providedPassword);
            Assert.AreNotEqual(_providedPassword, hash);
        }

        [Test]
        public void TestVerifyHashWithValidPassword()
        {
            // When given password is valid
            string hashedPassword = _service.Generate(_user, _providedPassword);
            bool isValid = _service.Validate(_user, hashedPassword, _providedPassword);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void TestVerifyHashWithInvalidPassword()
        {
            // When given password is invalid
            string hashedPassword = _service.Generate(_user, _providedPassword);
            bool isValid = _service.Validate(_user, hashedPassword, _invalidPassword);
            Assert.IsFalse(isValid);
        }
    }
}