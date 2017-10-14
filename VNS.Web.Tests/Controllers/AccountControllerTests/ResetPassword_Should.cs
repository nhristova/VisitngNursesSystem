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
        public class ResetPassword_Should
        {
            [TestMethod]
            public void RenderDefaultView_WhenPassedCodeIsNotNull()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                var accountController = new AccountController(userManager.Object, signInManager.Object);

                var code = "string";

                // Act & Assert
                accountController
                    .WithCallTo(c => c.ResetPassword(code))
                    .ShouldRenderDefaultView();
            }

            [TestMethod]
            public void RenderDefaultView_WhenPassedCodeNotNull()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                var accountController = new AccountController(userManager.Object, signInManager.Object);

                // Act & Assert
                accountController
                    .WithCallTo(c => c.ResetPassword((string)null))
                    .ShouldRenderView("Error");
            }
        }

        [TestClass]
        public class ResetPasswordConfirmation_Should
        {
            [TestMethod]
            public void RenderDefaultView_WhenCalled()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                var accountController = new AccountController(userManager.Object, signInManager.Object);

                // Act & Assert
                accountController
                    .WithCallTo(c => c.ResetPasswordConfirmation())
                    .ShouldRenderDefaultView();
            }
        }
    }
}
