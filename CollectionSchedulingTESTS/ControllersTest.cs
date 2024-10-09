using Moq;
using Xunit;
using Presentation.Controllers;
using Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.Dtos;
using Presentation.Model;
using Domain.Enums;
using CollectionSchedulingAPI.ViewModels;
using Presentation.Interface;

namespace CollectionSchedulingTESTS
{
    public class CollectionScheduleControllerTests
    {
        private readonly Mock<ICollectionScheduleService> _serviceMock;
        private readonly CollectionScheduleController _controller;

        public CollectionScheduleControllerTests()
        {
            _serviceMock = new Mock<ICollectionScheduleService>();
            _controller = new CollectionScheduleController(_serviceMock.Object);
        }

        [Fact]
        public async Task Register_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var model = new CollectionScheduleViewModel() { UserId = 1 };
            _serviceMock.Setup(s => s.Register(It.IsAny<CollectionScheduleDto>()))
                        .ReturnsAsync(new ResponseModel<bool>("Success", true));

            // Act
            var result = await _controller.Register(model);

            // Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            Xunit.Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var collectionSchedulesDto = new List<CollectionScheduleDto>
            {
                new CollectionScheduleDto { UserId = 1, WasteType = WasteType.Electronic },
                new CollectionScheduleDto { UserId = 2 }
            };
            _serviceMock.Setup(s => s.GetAll())
                        .ReturnsAsync(new ResponseModel<List<CollectionScheduleDto>>("Success", collectionSchedulesDto, true));

            // Act
            var actionResult = await _controller.GetAll();
            var okObjectResult = actionResult as OkObjectResult;

            // Assert
            Xunit.Assert.NotNull(okObjectResult);
            var responseModel = Xunit.Assert.IsType<ResponseModel<List<CollectionScheduleDto>>>(okObjectResult.Value);
            Xunit.Assert.Equal(200, okObjectResult.StatusCode);
        }
    }
}
