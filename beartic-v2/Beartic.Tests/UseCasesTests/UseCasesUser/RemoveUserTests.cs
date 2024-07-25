using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesUser
{
    [TestClass]
    public class RemoveUserTests
    {
        private readonly IUserRepository _userRepository = new FakeUserRepository();
        private readonly IRoleRepository _roleRepository = new FakeRoleRepository();

        [TestMethod]
        public void GivenExistsIdReturnResultStatus200()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var result = services.Remove("123");

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }

        [TestMethod]
        public void GivenNotExistsIdReturnResultStatus404()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var result = services.Remove("12");

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }
    }
}
