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
        public class ForgotPassword_Should
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
                    .WithCallTo(c => c.ForgotPassword())
                    .ShouldRenderDefaultView();
            }
        }

        [TestClass]
        public class ForgotPasswordConfirmation_Should
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
                    .WithCallTo(c => c.ForgotPasswordConfirmation())
                    .ShouldRenderDefaultView();
            }
        }
    }
}
