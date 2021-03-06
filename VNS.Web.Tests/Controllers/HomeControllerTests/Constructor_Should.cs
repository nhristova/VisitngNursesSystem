﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public partial class HomeControllerTests
    {

        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateControllerInstance_WhenParameterIsNotNull()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();

                // Act
                var homeController = new HomeController(visitsServiceMock.Object);

                // Assert
                Assert.IsNotNull(homeController);
                Assert.IsInstanceOfType(homeController, typeof(Controller));
            }

            [TestMethod]
            public void ThrowArgumentNullException_WhenParameterIsNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new HomeController(null));
            }

        }
    }
}
