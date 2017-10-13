using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Controllers;
using VNS.Web.Models.Visits;

namespace VNS.Web.Tests.Controllers.VisitsControllerTests
{
    public partial class VisitsControllerTests
    {
        [TestClass]
        public class List_Should
        {
            [TestMethod]
            public void RendersVisitsListPartialView_WhenCalled()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);
                
                visitsServiceMock.Setup(vs => vs.GetPage(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<string>())).Returns(new List<Visit>());
                visitsServiceMock.Setup(vs => vs.Count).Returns(5);

                // Act & Assert
                controller
                    .WithCallTo(c => c.List(1, 9, ""))
                    .ShouldRenderPartialView("_VisitsListPartial");
            }

            [TestMethod]
            public void CallGetPageOnce_WhenCalled()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                visitsServiceMock.Setup(vs => vs.GetPage(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<string>())).Returns(new List<Visit>());
                visitsServiceMock.Setup(vs => vs.Count).Returns(5);

                // Act
                controller.List();

                // Assert
                visitsServiceMock.Verify(vs => vs.GetPage(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<string>()), Times.Once());
            }
        }
    }
}