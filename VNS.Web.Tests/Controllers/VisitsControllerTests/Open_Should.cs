using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;
using VNS.Data.Models;
using VNS.Services.Contracts;
using VNS.Web.Controllers;
using VNS.Web.Models.Visits;
using Microsoft.AspNet.Identity.EntityFramework;

namespace VNS.Web.Tests.Controllers.VisitsControllerTests
{
    public partial class VisitsControllerTests
    {

        [TestClass]
        public class Open_Should
        {
            [TestMethod]
            public void RednerVisitDetailsPartialViewWithCorrectViewModel_WhenPassedExistingId()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                var testId = Guid.NewGuid();
                var visitModel = new Visit()
                {
                    Id = testId,
                    Date = new DateTime(2017, 10, 18),
                    // TODO: UserName is a field from IdentityUser which User inherits. Find out why this breaks the build
                    Nurse = new User() { UserName = "test" },
                    Description = "Test description",
                };

                visitsServiceMock.Setup(v => v.GetById(It.IsAny<Guid>())).Returns(visitModel);

                // Act & Assert
                controller
                       .WithCallTo(c => c.Open(testId))
                       .ShouldRenderPartialView("_VisitDetailsPartial")
                       .WithModel<VisitDetailsViewModel>(vm =>
                       {
                           Assert.AreEqual(visitModel.Id, vm.Id);
                           Assert.AreEqual(visitModel.Date, vm.Date);
                           Assert.AreEqual(visitModel.Description, vm.Description);
                           Assert.AreEqual(visitModel.CreatedOn, vm.CreatedOn);
                           Assert.AreEqual(visitModel.Nurse.UserName, vm.NurseName);
                           Assert.IsNull(vm.LastModifiedOn);
                       });
            }

            [TestMethod]
            public void RenderVisitDetailsPartialViewWithNullViewModel_WhenPassedIdDoesntExist()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                var testId = Guid.NewGuid();
                visitsServiceMock.Setup(v => v.GetById(It.IsAny<Guid>())).Returns((Visit)null);

                // Act & Assert
                controller
                    .WithCallTo(c => c.Open(testId))
                    .ShouldRenderPartialView("_VisitDetailsPartial")
                    .WithModel<VisitDetailsViewModel>(vm =>
                    {
                        Assert.IsTrue(vm.Date == default(DateTime));
                        Assert.IsNull(vm.Description);
                        Assert.IsNull(vm.NurseName);
                        Assert.IsNull(vm.LastModifiedOn);
                    });
            }

            // TODO: Testcase when  passed Id is null, currently not nullable. Consider why it makes sense to be nullable.
        }
    }
}