using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services;
using VNS.Services.Contracts;

namespace VNS.Web.Tests.Services.VisitsServiceTests
{
    public partial class VisitsServiceTests
    {
        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateServiceInstance_WhenParametersAreNotNull()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                // Act
                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                // Assert
                Assert.IsNotNull(visitsService);
                Assert.IsInstanceOfType(visitsService, typeof(IVisitsService));
            }

            [TestMethod]
            public void ThrowsArgumentNullException_WhenParameterIsNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new VisitsService(null, null));
            }
        }
    }
}