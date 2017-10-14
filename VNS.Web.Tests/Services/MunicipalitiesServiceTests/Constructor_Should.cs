using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Services;
using VNS.Services.Contracts;

namespace VNS.Web.Tests.Services.MunicipalitiesServiceTests
{
    public partial class MunicipalitiesServiceTests
    {
        [TestClass]
        public class Constructor_Should
        {
            [TestMethod]
            public void CreateServiceInstance_WhenParametersAreNotNull()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Municipality>>();

                // Act
                var municipalitiesService = new MunicipalitiesService(efRepositoryMock.Object);

                // Assert
                Assert.IsNotNull(municipalitiesService);
                Assert.IsInstanceOfType(municipalitiesService, typeof(IMunicipalitiesService));
            }

            [TestMethod]
            public void ThrowsArgumentNullException_WhenParameterIsNull()
            {
                // Arrange & Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => new MunicipalitiesService(null));
            }
        }
    }
}
