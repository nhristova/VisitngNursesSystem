using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services;

namespace VNS.Web.Tests.Services.VisitsServiceTests
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
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var visit = new Visit();
                efRepositoryMock.SetupGet(r => r.All).Returns(new List<Visit>().AsQueryable);

                // Act
                visitsService.GetAll();

                // Assert
                efRepositoryMock.Verify(r => r.All, Times.Once);
            }            
        }

        [TestClass]
        public class Count_Should
        {
            [TestMethod]
            public void GetRepositoryAll_WhenCalled()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var visit = new Visit();
                efRepositoryMock.SetupGet(r => r.All).Returns(new List<Visit>().AsQueryable);

                // Act
                var result = visitsService.Count;

                // Assert
                efRepositoryMock.Verify(r => r.All, Times.Once);
            }
        }
    }
}