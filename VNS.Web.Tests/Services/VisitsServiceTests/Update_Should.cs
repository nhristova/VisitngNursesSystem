﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services;

namespace VNS.Web.Tests.Services.VisitsServiceTests
{
    public partial class VisitsServiceTests
    {
        [TestClass]
        public class Update_Should
        {
            [TestMethod]
            public void CallRepositoryUpdateAndCommitOnce_WhenPassedVisitIsNotNull()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                var visit = new Visit();

                efRepositoryMock.Setup(r => r.Update(visit));
                commitMock.Setup(c => c.Commit());

                // Act
                visitsService.Update(visit);

                // Assert
                efRepositoryMock.Verify(r => r.Update(visit), Times.Once);
                commitMock.Verify(c => c.Commit(), Times.Once);
            }         
            
            [TestMethod]  
            public void ThrowException_WhenPassedVisitIsNull()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var visitsService = new VisitsService(efRepositoryMock.Object, commitMock.Object);

                efRepositoryMock.Setup(r => r.Update(It.IsAny<Visit>()));

                // Act & Assert
                Assert.ThrowsException<ArgumentNullException>(() => visitsService.Update(null));
            }
        }
    }
}