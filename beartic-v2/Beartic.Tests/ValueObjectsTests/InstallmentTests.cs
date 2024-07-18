using Beartic.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.ValueObjectsTests
{
    [TestClass]
    public class InstallmentTests
    {
        [TestMethod]
        public void InstallmentPriceMustBe500()
        {
            Installment installment = new Installment(1000, 2);
            Assert.IsTrue(installment.InstallmentPrice == 500);
        }

        [TestMethod]
        public void InstallmentPriceMustBe500WhenPaidInstallment()
        {
            Installment installment = new Installment(1000, 2);
            installment.PayInstallment(500);

            Assert.IsTrue(installment.Price == 500 && installment.Installments == 1);
        }

        [TestMethod]
        public void InstallmentPriceMustBe800AndInstallments2WhenPaidInstallment()
        {
            Installment installment = new Installment(1000, 2);
            installment.PayInstallment(200);

            Assert.IsTrue(installment.Price == 800 && installment.Installments == 2);
        }

        [TestMethod]
        public void InstallmentPriceMustBe200AndInstallments5WhenParcelInstallment()
        {
            Installment installment = new Installment(1000, 2);
            installment.Parcel(5);

            Assert.IsTrue(installment.InstallmentPrice == 200 && installment.Installments == 5);
        }
    }
}
