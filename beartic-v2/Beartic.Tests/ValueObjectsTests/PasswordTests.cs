using Beartic.Auth.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.ValueObjectsTests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void ReturnSucessGivenValidPassword()
        {
            Password password = new Password("123456789");
            Assert.IsTrue(password.Valid);
        }

        [TestMethod]
        public void ReturnFalseGivenInvalidPassword()
        {
            Password password = new Password("1234");
            Assert.IsTrue(password.Invalid);
        }

        [TestMethod]
        public void ReturnTrueWhenPasswordHashed()
        {
            Password password = new Password("123456789");
            Assert.IsTrue(password.PasswordHash != "123456789");
        }

        [TestMethod]
        public void ReturnTrueWhenCreateSaltKey()
        {
            Password password = new Password("123456789");
            Assert.IsTrue(password.SaltKey != string.Empty);
        }
    }
}
