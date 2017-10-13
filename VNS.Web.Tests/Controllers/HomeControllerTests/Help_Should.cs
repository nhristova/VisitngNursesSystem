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
        public class Help_Should
        {
            [TestMethod]
            public void ReturnViewResultInstance_WhenCalled()
            {
                // Arrange
                var visitServiceMock = new Mock<IVisitsService>();
                HomeController controller = new HomeController(visitServiceMock.Object);

                // Act
                var result = controller.Help();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
    }
}