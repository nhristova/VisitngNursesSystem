using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.HomeControllerTests
{
    public partial class HomeControllerTests
    {
        [TestClass]
        public class About_Should
        {
            [TestMethod]
            public void PassCorrectViewBagMessage_WhenCalled()
            {
                // Arrange
                var visitServiceMock = new Mock<IVisitsService>();
                HomeController controller = new HomeController(visitServiceMock.Object);

                // Act
                var result = controller.About() as ViewResult;

                // Assert
                Assert.AreEqual("Helping nurses help families with babies.", result.ViewBag.Message);
            }
        }
    }
}
