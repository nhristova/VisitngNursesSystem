using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;
using VNS.Auth.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.AccountControllerTests
{
    [TestClass]
    public partial class AccountControllerTests
    {
        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateControllerInstance_WhenNoParametersPassed()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                // Act
                var accountController = new AccountController();

                // Assert
                Assert.IsNotNull(accountController);
                Assert.IsInstanceOfType(accountController, typeof(Controller));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenParametersAreNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new AccountController(null, null));
            }
        }
    }
}