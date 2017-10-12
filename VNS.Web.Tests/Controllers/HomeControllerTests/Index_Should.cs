using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VNS.Web.Controllers;
using VNS.Services.Contracts;
using Moq;

namespace VNS.Web.Tests.Controllers.HomeControllerTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var visitServiceMock = new Mock<IVisitsService>();
            HomeController controller = new HomeController(visitServiceMock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var visitServiceMock = new Mock<IVisitsService>();
            HomeController controller = new HomeController(visitServiceMock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Helping nurses help families with babies.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Help()
        {
            // Arrange
            var visitServiceMock = new Mock<IVisitsService>();
            HomeController controller = new HomeController(visitServiceMock.Object);

            // Act
            ViewResult result = controller.Help() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
