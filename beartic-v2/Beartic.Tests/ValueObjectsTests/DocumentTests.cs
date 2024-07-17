using Beartic.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.ValueObjectsTests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ReturnSuccessGivenValidCPF()
        {
            Document document = new Document("99403111097", Core.Enums.EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void ReturnFalseGivenInvalidCPF()
        {
            Document document = new Document("38876088017", Core.Enums.EDocumentType.CPF);
            Assert.IsFalse(document.Valid);
        }
    }
}
