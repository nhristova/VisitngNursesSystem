using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services;

namespace VNS.Web.Tests.Services.VisitsServiceTests
{
    public partial class VisitsControllerTests
    {
        [TestClass]
        public class GetById_Should
        {
            [TestMethod]
            public void ReturnVisit_WhenPassedGuidHasValue()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                Guid? id = Guid.NewGuid();

                efRepositoryMock.Setup(r => r.GetById(id.Value)).Returns(new Visit() { Id = id.Value });

                // Act
                var result = visitsService.GetById(id.Value);

                // Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void ReturnNullVisit_WhenPassedGuidIsNull()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                // Act
                Visit result = visitsService.GetById(null);

                // Assert
                Assert.IsNull(result);
            }
        }
    }
}