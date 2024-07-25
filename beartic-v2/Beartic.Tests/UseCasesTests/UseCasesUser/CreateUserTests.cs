using Beartic.Auth.Interfaces;
using Beartic.Auth.UseCases.UserUseCases;
using Beartic.Auth.UseCases.UserUseCases.UserDtos;
using Beartic.Shared.Enums;
using Beartic.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beartic.Tests.UseCasesTests.UseCasesUser
{
    [TestClass]
    public class CreateUserTests
    {
        private readonly IUserRepository _userRepository = new FakeUserRepository();
        private readonly IRoleRepository _roleRepository = new FakeRoleRepository();

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new CreateUserDto("124", "user1", "kaique", "alves", "email@teste.com", "65950707079", EDocumentType.CPF, "11922113322", "123456789", new List<string> { "123", "12", "1"});
            var response = services.Create(request);

            Assert.IsTrue(response.Result.Success && response.Result.Status == 201);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus401()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new CreateUserDto("", "", "", "", "teste.com", "65950707078", EDocumentType.CPF, "119213322", "123489", new List<string> { "123", "12", "1" });
            var response = services.Create(request);

            Assert.IsTrue(!response.Result.Success && response.Result.Status == 401 && response.Result.Message == "Usuário não cadastrado" && response.Result.Errors.Any());
        }

        [TestMethod]
        public void GivenUserExistsReturnResultStatus401()
        {
            var services = new UserServices(_userRepository, _roleRepository);
            var request = new CreateUserDto("123", "user1", "kaique", "alves", "exists@email.com", "65950707079", EDocumentType.CPF, "11922113322", "123456789", new List<string> { "123", "12", "1" });
            var response = services.Create(request);

            Assert.IsTrue(!response.Result.Success && response.Result.Status == 401 && response.Result.Message == "O documento informado já está cadastrado.");
        }
    }
}
