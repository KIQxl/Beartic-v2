using Beartic.Shared.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.ValueObjectsTests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ReturnTrueGivenValidName()
        {
            Name name = new Name("Kaique", "Alves");
            Assert.IsTrue(name.Valid);
        }

        [TestMethod]
        public void ReturnFalseGivenInvalidName()
        {
            Name name = new Name("K", "");
            Assert.IsTrue(name.Invalid);
        }
    }
}
