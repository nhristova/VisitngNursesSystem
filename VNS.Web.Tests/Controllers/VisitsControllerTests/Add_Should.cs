using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Controllers;
using VNS.Web.Models.Visits;

namespace VNS.Web.Tests.Controllers.VisitsControllerTests
{
    public partial class VisitControllerTests
    {
        [TestClass]
        public class Add_Should
        {
            [TestMethod]
            public void RenderDefaultView_WhenCalled()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                // Act & Assert
                controller
                    .WithCallTo(c => c.Add())
                    .ShouldRenderDefaultView();
            }

            [TestMethod]
            public void RenderVisitDetailsPartialWithInvalidViewModel_WhenPostedInvalidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                controller.ModelState.AddModelError("isValid", "view model not valid");

                var visitDetailsModel = new VisitDetailsViewModel();

                // Act & Assert
                controller
                       .WithCallTo(c => c.Add(visitDetailsModel))
                       .ShouldRenderDefaultView()
                       .WithModel(visitDetailsModel);
            }

            [TestMethod]
            public void CallAddOnce_WhenPostedValidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                var visitDetailsModel = new VisitDetailsViewModel();

                visitsServiceMock.Setup(vs => vs.Add(It.IsAny<Visit>()));
                
                // Act
                controller.Add(visitDetailsModel);

                // Assert
                visitsServiceMock.Verify(vs => vs.Add(It.IsAny<Visit>()), Times.Once());
            }

            [TestMethod]
            public void RedirectToIndexWithTempDataMessage_WhenPostedValidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                var visitDetailsModel = new VisitDetailsViewModel();

                // Act & Assert
                controller
                    .WithCallTo(c => c.Add(visitDetailsModel))
                    .ShouldRedirectTo("Index");

                controller.ShouldHaveTempDataProperty("message", "Visit added successfully");
            }
        }
    }
}