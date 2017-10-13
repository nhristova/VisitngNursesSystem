using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VNS.Services.Contracts;
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
            public void CreateIControllerInstance_WhenParameterIsNotNull()
            {
                // TODO: complete
                // Arrange
                var usersServiceMock = new Mock<IFamiliesService>();

                // Act
                //var accountController = new AccountController(null, null);

                // Assert
                //Assert.IsNotNull(accountController);
                //Assert.IsInstanceOfType(accountController, typeof(Controller));
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