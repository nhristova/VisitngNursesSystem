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
            public void CreateControllerInstance_WhenPassedManagersAreNotNull()
            {
                // Arrange
                var userManager = new Mock<IUserService>();
                var signInManager = new Mock<ISignInService>();

                // Act
                var accountController = new AccountController(userManager.Object, signInManager.Object);

                // Assert
                Assert.IsNotNull(accountController);
                Assert.IsInstanceOfType(accountController, typeof(Controller));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenPassedUserManagerIsNull()
            {
                // Arrange
                var signInManager = new Mock<ISignInService>();

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new AccountController(null, signInManager.Object));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenPassedSignInManagerIsNull()
            {
                // Act
                var userManager = new Mock<IUserService>();

                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new AccountController(userManager.Object, null));
            }
        }
    }
}