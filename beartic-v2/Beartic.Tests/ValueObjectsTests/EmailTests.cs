using Beartic.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.ValueObjectsTests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void ReturnFalseGivenInvalidEmailAddress()
        {
            Email email = new Email("kaique.com.br");

            Assert.IsFalse(email.Valid);
        }

        [TestMethod]
        public void ReturnTrueGivenValidEmailAddress()
        {
            Email email = new Email("kaique@email.com.br");

            Assert.IsTrue(email.Valid);
        }
    }
}
