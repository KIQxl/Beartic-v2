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

        [TestMethod]
        public void GivenValidRequestReturnResultStatus201()
        {
            var services = new UserServices(_userRepository);
            var request = new UpdateUserDto("123", "user", "user", "user", "email@email.com", "11299338844");
            var result = services.Update(request);

            Assert.IsTrue(result.Result.Success && result.Result.Status == 201);
        }

        [TestMethod]
        public void GivenValidRequestButUserIdNotExistsReturnResultStatus404()
        {
            var services = new UserServices(_userRepository);
            var request = new UpdateUserDto("12", "user", "user", "user", "email@email.com", "11299338844");
            var result = services.Update(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 404);
        }

        [TestMethod]
        public void GivenInvalidRequestReturnResultStatus401()
        {
            var services = new UserServices(_userRepository);
            var request = new UpdateUserDto("123", "", "user", "user", "emailemail.com", "11238844");
            var result = services.Update(request);

            Assert.IsTrue(!result.Result.Success && result.Result.Status == 401 && result.Result.Errors.Any());
        }
    }
}
