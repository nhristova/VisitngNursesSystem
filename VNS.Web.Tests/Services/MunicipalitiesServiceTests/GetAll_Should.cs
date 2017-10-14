using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services;

namespace VNS.Web.Tests.Services.MunicipalitiesServiceTests
{
    public partial class VisitsServiceTests
    {
        [TestClass]
        public class GetAll_Should
        {
            [TestMethod]
            public void GetRepositoryAll_WhenCalled()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Municipality>>();

                var municipalitiesService = new MunicipalitiesService(efRepositoryMock.Object);

                var visit = new Visit();
                efRepositoryMock.SetupGet(r => r.All).Returns(new List<Municipality>().AsQueryable);

                // Act
                municipalitiesService.GetAll();

                // Assert
                efRepositoryMock.Verify(r => r.All, Times.Once);
            }
        }
    }
}
