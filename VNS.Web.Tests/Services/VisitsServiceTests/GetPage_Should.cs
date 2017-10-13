using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
        public class GetPage_Should
        {
            [TestMethod]
            public void ReturnListOfVisits_WhenCalledWithoutParameters()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var allVisits = new List<Visit>();
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                               
                efRepositoryMock.SetupGet(r => r.All).Returns(allVisits.AsQueryable);

                // Act
                var result = visitsService.GetPage(It.IsAny<short>(), It.IsAny<short>(), It.IsAny<string>());

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<Visit>));
            }

            [TestMethod]
            public void ReturnVisitsCount_WhichMatchesPageSizePassed()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var allVisits = new List<Visit>();
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });

                efRepositoryMock.SetupGet(r => r.All).Returns(allVisits.AsQueryable);

                short pageSize = 3;

                // Act
                var result = visitsService.GetPage(1, pageSize, "CreatedOn");

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<Visit>));
                Assert.IsTrue(result.Count() == pageSize);
            }

            [TestMethod]
            public void ReturnDefaultVisitCount_WhenPageSizePassedIsNegative()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var allVisits = new List<Visit>();
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });
                allVisits.Add(new Visit() { CreatedOn = new DateTime() });

                efRepositoryMock.SetupGet(r => r.All).Returns(allVisits.AsQueryable);

                short pageSize = -3;

                // Act
                var result = visitsService.GetPage(1, pageSize, "CreatedOn");

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<Visit>));
                Assert.IsTrue(result.Count() == 9);
            }
        }
    }
}