using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Controllers;
using VNS.Web.Models.Visits;
using Microsoft.AspNet.Identity.EntityFramework;
using VNS.Auth.Contracts;

namespace VNS.Web.Tests.Controllers.VisitsControllerTests
{
    public partial class VisitsControllerTests
    {
        [TestClass]
        public class Edit_Should
        {
            [TestMethod]
            public void RenderVisitEditPartialWithCorrectViewModel_WhenPassedIdExists()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUserService>();
                var pageServiceMock = new Mock<IPageService<Visit>>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object, pageServiceMock.Object);

                var testId = Guid.NewGuid();
                var visitModel = new Visit()
                {
                    Id = testId,
                    Date = new DateTime(2017, 10, 18),
                    UserName = "test",                    
                    Description = "Test description",
                };

                visitsServiceMock.Setup(v => v.GetById(It.IsAny<Guid>())).Returns(visitModel);

                // Act & Assert
                controller
                       .WithCallTo(c => c.Edit(testId))
                       .ShouldRenderPartialView("_VisitEditPartial")
                       .WithModel<VisitDetailsViewModel>(vm =>
                       {
                           Assert.AreEqual(visitModel.Id, vm.Id);
                           Assert.AreEqual(visitModel.Date, vm.Date);
                           Assert.AreEqual(visitModel.Description, vm.Description);
                           Assert.AreEqual(visitModel.CreatedOn, vm.CreatedOn);
                           Assert.AreEqual(visitModel.UserName, vm.NurseName);
                           Assert.IsNull(vm.LastModifiedOn);
                       });
            }

            [TestMethod]
            public void RenderVisitDetailsPartialWithInvalidViewModel_WhenPostedInvalidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUserService>();
                var pageServiceMock = new Mock<IPageService<Visit>>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object, pageServiceMock.Object);

                controller.ModelState.AddModelError("isValid", "view model not valid");

                var visitDetailsModel = new VisitDetailsViewModel();

                // Act & Assert
                controller
                       .WithCallTo(c => c.Edit(visitDetailsModel))
                       .ShouldRenderPartialView("_VisitEditPartial")
                       .WithModel(visitDetailsModel);
            }

            [TestMethod]
            public void CallUpdateOnce_WhenPostedValidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUserService>();
                var pageServiceMock = new Mock<IPageService<Visit>>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object, pageServiceMock.Object);

                var visitModel = new Visit();
                var visitDetailsModel = new VisitDetailsViewModel();

                visitsServiceMock.Setup(vs => vs.Update(visitModel));
                visitsServiceMock.Setup(vs => vs.GetById(It.IsAny<Guid>())).Returns(visitModel);

                // Act
                controller.Edit(visitDetailsModel);

                // Assert
                visitsServiceMock.Verify(vs => vs.Update(visitModel), Times.Once());
            }

            [TestMethod]
            public void RenderVisitDetailsPartialWithCorrectViewModel_WhenPostedValidViewModel()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUserService>();
                var pageServiceMock = new Mock<IPageService<Visit>>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object, pageServiceMock.Object);

                var visitModel = new Visit();
                var visitDetailsModel = new VisitDetailsViewModel();

                visitsServiceMock.Setup(vs => vs.Update(visitModel));
                visitsServiceMock.Setup(v => v.GetById(It.IsAny<Guid>())).Returns(visitModel);

                // TODO: Consider if this test should check the proper mapping between data and view models. It is tested in the first test above but because I moved mapping to happen in view model, mabye shold be tested in a separate test only for view models?
                // Act & Assert
                controller
                    .WithCallTo(c => c.Edit(visitDetailsModel))
                    .ShouldRenderPartialView("_VisitDetailsPartial")
                    .WithModel(visitDetailsModel);
            }
        }
    }
}