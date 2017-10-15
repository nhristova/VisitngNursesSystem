using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNS.Data.Models;
using VNS.Data.Repositories;
using VNS.Data.SaveContext;
using VNS.Services;

namespace VNS.Web.Tests.Services.PageServiceTests
{
    public partial class PageServiceTests
    {

        [TestClass]
        public class Count_Should
        {
            [TestMethod]
            public void GetRepositoryAll_WhenCalled()
            {
                // Arrange
                var efRepositoryMock = new Mock<IEfRepository<Visit>>();
                var commitMock = new Mock<ISaveContext>();

                var pageService = new PageService<Visit>(efRepositoryMock.Object);

                var visit = new Visit();
                efRepositoryMock.SetupGet(r => r.All).Returns(new List<Visit>().AsQueryable);

                // Act
                var result = pageService.Count;

                // Assert
                efRepositoryMock.Verify(r => r.All, Times.Once);
            }
        }

    }
}
