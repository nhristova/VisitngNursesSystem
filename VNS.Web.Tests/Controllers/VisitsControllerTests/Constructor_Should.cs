using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.VisitsControllerTests
{
    [TestClass]
    public partial class VisitsControllerTests
    {
        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateControllerInstance_WhenParametersAreNotNull()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                // Act
                var visitsController = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                // Assert
                Assert.IsNotNull(visitsController);
                Assert.IsInstanceOfType(visitsController, typeof(Controller));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenParametersAreNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new VisitsController(null, null, null));
            }
        }
    }
}