using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
        public class Index_Should
        {
            [TestMethod]
            public void ReturnViewResultInstance_WhenCalled()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                municipalitiesServiceMock.Setup(m => m.GetAll()).Returns(new List<Municipality>());

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                // Act
                var result = controller.Index();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }

            [TestMethod]
            public void RenderViewResultWithCorrectViewModel_WhenCalled()
            {
                // Arrange
                var visitsServiceMock = new Mock<IVisitsService>();
                var municipalitiesServiceMock = new Mock<IMunicipalitiesService>();
                var usersServiceMock = new Mock<IUsersService>();

                var controller = new VisitsController(visitsServiceMock.Object, municipalitiesServiceMock.Object, usersServiceMock.Object);

                var municipalities = new List<Municipality>()
                {
                    new Municipality { Name = "MVM", Towns = new List<Town>() }
                };

                municipalitiesServiceMock.Setup(m => m.GetAll()).Returns(municipalities);
                
                var expectedVM = new MunicipalityViewModel() { Name = "MVM", Towns = new List<string>() };

                // Act & Assert
                controller
                    .WithCallTo(c => c.Index(1, 9, "CreatedOn"))
                    .ShouldRenderDefaultView()
                    .WithModel<SearchViewModel>(vm =>
                   {
                       Assert.IsTrue(vm.Municipalities.Any(m => m.Name == expectedVM.Name));
                   });
            }
        }
    }
}