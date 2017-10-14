using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services;

namespace VNS.Web.Tests.Services.FamiliesServiceTests
{
    public partial class FamiliesServiceTests
    {
        [TestClass]
        public class GetAll_Should
        {
            [TestMethod]
            public void GetRepositoryAll_WhenCalled()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Family>>();

                var familiesService = new FamiliesService(efRepositoryMock.Object);

                var visit = new Visit();
                efRepositoryMock.SetupGet(r => r.All).Returns(new List<Family>().AsQueryable);

                // Act
                familiesService.GetAll();

                // Assert
                efRepositoryMock.Verify(r => r.All, Times.Once);
            }
        }
    }
}
