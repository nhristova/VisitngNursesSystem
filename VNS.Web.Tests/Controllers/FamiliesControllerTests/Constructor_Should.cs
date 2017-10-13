using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.FamiliesControllerTests
{
    [TestClass]
    public partial class FamiliesControllerTests
    {
        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateIControllerInstance_WhenParameterIsNotNull()
            {
                // Arrange
                var familiesServiceMock = new Mock<IFamiliesService>();

                // Act
                var familiesController = new FamiliesController(familiesServiceMock.Object);

                // Assert
                Assert.IsNotNull(familiesController);
                Assert.IsInstanceOfType(familiesController, typeof(Controller));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenParameterIsNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new FamiliesController(null));
            }

        }
    }
}
