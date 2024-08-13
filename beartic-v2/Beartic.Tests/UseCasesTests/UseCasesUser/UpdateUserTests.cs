using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesUser
{
    [TestClass]
    public class UpdateUserTests
    {
        private readonly IUserRepository _userRepository = new FakeUserRepository();
        private readonly IRoleRepository _roleRepository = new FakeRoleRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new UpdateUserDto("123", "user", "user", "user", "email@email.com", "11299338844", "79008677083", Shared.Enums.EDocumentType.CPF);
            var result = services.Update(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenValidRequestButUserIdNotExistsReturnResultStatus404()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new UpdateUserDto("12", "user", "user", "user", "email@email.com", "11299338844", "79008677083", Shared.Enums.EDocumentType.CPF);
            var result = services.Update(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus400()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new UpdateUserDto("123", "", "user", "user", "emailemail.com", "11238844", "79008677083", Shared.Enums.EDocumentType.CPF);
            var result = services.Update(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 400 && result.Result.Errors.Any());
        }

        [TestMethod]
        public void GivenValidRequestReturnResultStatus200AndAddRole()
        {
            var services = new UserServices(_userRepository, _roleRepository);

            var result = services.AddRole(new AlterRole { roleId = "123", userId = "123" });

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }

        [TestMethod]
        public void GivenValidRequestReturnResultStatus200AndRemoveRole()
        {
            var services = new UserServices(_userRepository, _roleRepository);

            var result = services.RemoveRole(new AlterRole { roleId = "123", userId = "123" });

            Assert.IsTrue(result.Result.Success && result.Result.Status == 200);
        }
    }
}
