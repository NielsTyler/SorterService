using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using SortingService.API.Interfaces;
using SortingService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SortingService.Tests
{
    public class SortingControllerTests
    {
        [Fact]
        public void SortingControllerTest()
        {
            //var loggerMock = new Mock<ILogger>();
            var loggerMock = new Mock<ILogger<SortingProcessorController>>();
            var fileManager = new Mock<IFileManager>();
            var sortingService = new Mock<ISortingService>();
            //SortingProcessorController controller = new SortingProcessorController(loggerMock.Object, sortingService.Object, fileManager.Object);

        }
    }
}
