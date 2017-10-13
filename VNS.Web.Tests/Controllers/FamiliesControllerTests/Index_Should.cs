using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using VNS.Services.Contracts;
using VNS.Web.Controllers;

namespace VNS.Web.Tests.Controllers.FamiliesControllerTests
{
    public partial class FamiliesControllerTests
    {
        [TestClass]
        public class Index_Should
        {
            [TestMethod]
            public void ReturnViewResultInstance_WhenCalled()
            {
                // Arrange
                var familiesServiceMock = new Mock<IFamiliesService>();
                var controller = new FamiliesController(familiesServiceMock.Object);

                // Act
                var result = controller.Index();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
    }
}