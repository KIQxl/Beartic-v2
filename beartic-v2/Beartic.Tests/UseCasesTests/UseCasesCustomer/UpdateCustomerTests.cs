﻿using Beartic.Core.Interfaces;
using Beartic.Core.UseCases.CustomerUseCases;
using Beartic.Core.UseCases.CustomerUseCases.CustomerDtos;
using Beartic.Shared.Enums;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesCustomer
{
    [TestClass]
    public class UpdateCustomerTests
    {
        private ICustomerRepository _customerRepository = new FakeCustomerRepository();

        [TestMethod]
        public void GivenValidUpdateCustomerRequestReturnResultStatus201ResultSuccessTrue()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var updateCustomerDto = new UpdateCustomerDto("123", "Update", "lastname update", "update@email.com", "11922334455", "45261517850", EDocumentType.CPF, "rua", "cidade", "estado", "cep", "país", "numero");
            var result = customerServices.Update(updateCustomerDto);

            Assert.IsTrue(result.Result.Success && result.Result.Message == "Dados do cliente alterados com sucesso" && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenNullCustomerInDatabaseReturnResultStatus404()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var updateCustomerDto = new UpdateCustomerDto("1", "Update", "lastname update", "update@email.com", "11922334455", "45261517850", EDocumentType.CPF, "rua", "cidade", "estado", "cep", "país", "numero");
            var result = customerServices.Update(updateCustomerDto);

            Assert.IsTrue(!result.Result.Success && result.Result.Message == "Não foi possível encontrar o cliente" && result.Result.Status == 404);
        }

        [TestMethod]
        public void GivenInvalidCustomerRequestReturnResultStatus400()
        {
            var customerServices = new CustomerServices(_customerRepository);
            var updateCustomerDto = new UpdateCustomerDto("123", "Update", "lastname ", "updateemail.com", "11922334455", "", EDocumentType.CPF, "rua", "", "estado", "cep", "país", "numero");
            var result = customerServices.Update(updateCustomerDto);

            Assert.IsTrue(!result.Result.Success && result.Result.Message == "Não foi possível alterar os dados" && result.Result.Status == 400 && result.Result.Errors.Any());
        }
    }
}
