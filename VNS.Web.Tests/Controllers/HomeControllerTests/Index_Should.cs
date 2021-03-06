﻿using System.Web.Mvc;
using VNS.Web.Controllers;
using VNS.Services.Contracts;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VNS.Web.Tests.Controllers.HomeControllerTests
{
    public partial class HomeControllerTests
    {
        [TestClass]
        public class Index_Should
        {
            [TestMethod]
            public void ReturnViewResultInstance_WhenCalled()
            {
                // Arrange
                var visitServiceMock = new Mock<IVisitsService>();
                HomeController controller = new HomeController(visitServiceMock.Object);

                // Act
                var result = controller.Index();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
    }
}