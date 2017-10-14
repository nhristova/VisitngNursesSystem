using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;
using VNS.Auth.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.AccountControllerTests
{
    public partial class AccountControllerTests
    {
        [TestClass]
        public class LogIn_Should
        {
            [TestMethod]
            public void RenderDefaultViewAndViewBagWithUrl_WhenPassedUrlIsNotNull()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                var accountController = new AccountController(userManager.Object, signInManager.Object);

                var url = "url";

                // Act & Assert
                accountController
                    .WithCallTo(c => c.Login(url))
                    .ShouldRenderDefaultView();

                Assert.AreEqual(url, accountController.ViewBag.ReturnUrl);
            }
        }

        [TestClass]
        public class ExternalLoginFailure_Should{

            [TestMethod]
            public void RenderDefaultView_WhenCalled()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                var accountController = new AccountController(userManager.Object, signInManager.Object);

                // Act & Assert
                accountController
                    .WithCallTo(c => c.ExternalLoginFailure())
                    .ShouldRenderDefaultView();
            }
        }
    }
}