﻿using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesUser
{
    [TestClass]
    public class LoginUserTests
    {
        private readonly IUserRepository _userRepository = new FakeUserRepository();
        private readonly IRoleRepository _roleRepository = new FakeRoleRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus200()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new RequestLoginDto("user", "123456789");
            var result = services.Login(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }

        [TestMethod]
        public void GivenInvalidPasswordRequestReturnResultStatus400()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new RequestLoginDto("user", "12345689");
            var result = services.Login(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 400);
        }

        [TestMethod]
        public void GivenInvalidUsernameRequestReturnResultStatus404()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new RequestLoginDto("uer", "123456789");
            var result = services.Login(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
