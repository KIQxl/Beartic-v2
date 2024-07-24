﻿using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesUser
{
    [TestClass]
    public class GetUserTests
    {
        private readonly IUserRepository _userRepository = new FakeUserRepository();

        [TestMethod]
        public void GivenValidRequestIdReturnResultStatus200()
        {
            var services = new UserServices(_userRepository);
            var result = services.GetById("123");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }

        [TestMethod]
        public void GivenNotExistsIdReturnResultStatus404()
        {
            var services = new UserServices(_userRepository);
            var result = services.GetById("124");

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
