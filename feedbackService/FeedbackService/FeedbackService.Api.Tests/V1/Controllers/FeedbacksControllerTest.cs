using AutoFixture;
using FeedbackService.Api.V1.Controllers;
using FeedbackService.Core.Interfaces.Services;
using FeedbackService.Core.Models;
using FeedbackService.Infrastructure.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FeedbackService.Api.Tests.V1.Controllers
{
    public class FeedbacksControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IFeedbackService> _serviceMock;
        private readonly FeedbacksController _sut; //sut - System Under Test

        public FeedbacksControllerTest()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IFeedbackService>>();
            _sut = new FeedbacksController(_serviceMock.Object);//creates the implementation in-memory
        }
        [Fact]
        public async Task GetFeedbacks_ShouldReturnOkResponse_WhenDataFound()
        {
            //Arrange
            var feedbacksMock = _fixture.Create<IEnumerable<FeedbackDTO>>();
            _serviceMock.Setup(x => x.GetAllFeedbacksAsync()).ReturnsAsync(feedbacksMock); //Service method here

            //Act
            var result = await _sut.GetFeedbacks().ConfigureAwait(false); //controller method here

            //Assert
            //Assert.NotNull(result); //Instead of this we are using FluentAssertion
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<IEnumerable<FeedbackDTO>>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(feedbacksMock.GetType());
            _serviceMock.Verify(x => x.GetAllFeedbacksAsync(), Times.Once());
        }

        [Fact]
        public async Task GetFeedbacks_ShouldReturnNotFound_WhenDataNotFound()
        {
            //Arrange
            List<FeedbackDTO> response = null;
            _serviceMock.Setup(x => x.GetAllFeedbacksAsync()).ReturnsAsync(response);

            //Act
            var result = await _sut.GetFeedbacks().ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<NotFoundResult>();
            _serviceMock.Verify(x => x.GetAllFeedbacksAsync(), Times.Once());
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnOkResponse_WhenValidInput()
        {
            //Arrange
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            var id = _fixture.Create<int>();
            _serviceMock.Setup(x => x.GetFeedbackByIdAsync(id)).ReturnsAsync(feedbackMock);

            //Act
            var result = await _sut.GetFeedbackById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<FeedbackDTO>>();
            result.Result.Should().BeAssignableTo<OkObjectResult>();
            result.Result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(feedbackMock.GetType());
            _serviceMock.Verify(x => x.GetFeedbackByIdAsync(id), Times.Once());
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnNotFound_WhenNoDataFound()
        {
            // Arrange
            FeedbackDTO response = null;
            var id = _fixture.Create<int>();
            _serviceMock.Setup(x => x.GetFeedbackByIdAsync(id)).ReturnsAsync(response);

            // Act
            var result = await _sut.GetFeedbackById(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<NotFoundResult>();
            _serviceMock.Verify(x => x.GetFeedbackByIdAsync(id), Times.Once());
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnBadRequest_WhenInputIsEqualsZero()
        {
            // Arrange
            var response = _fixture.Create<Feedback>();
            int id = 0;

            // Act
            var result = await _sut.GetFeedbackById(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnBadRequest_WhenInputIsLessThanZero()
        {
            // Arrange
            var response = _fixture.Create<FeedbackDTO>();
            int id = -1;

            // Act
            var result = await _sut.GetFeedbackById(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
        }
        [Fact]
        public async Task CreateFeedback_ShouldReturnOkResponse_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<FeedbackDTO>();
            var response = _fixture.Create<FeedbackDTO>();
            _serviceMock.Setup(x => x.CreateFeedbackAsync(request)).ReturnsAsync(response);

            // Act
            var result = await _sut.CreateFeedback(request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<ActionResult<FeedbackDTO>>();
            result.Result.Should().BeAssignableTo<CreatedAtRouteResult>();
            _serviceMock.Verify(x => x.CreateFeedbackAsync(response), Times.Never());
        }
        [Fact]
        public async Task CreateFeedback_ShouldReturnBadRequest_WhenInvalidRequest()
        {
            // Arrange
            var request = _fixture.Create<FeedbackDTO>();
            _sut.ModelState.AddModelError("Subject", "The Subject field is required.");
            var response = _fixture.Create<FeedbackDTO>();

            // Act
            var result = await _sut.CreateFeedback(request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Result.Should().BeAssignableTo<BadRequestResult>();
        }
        [Fact]
        public async Task DeleteFeedback_ShouldReturnNoContents_WhenDeletedARecord()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _serviceMock.Setup(x => x.DeleteFeedbackAsync(id)).ReturnsAsync(true);

            // Act
            var result = await _sut.DeleteFeedback(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();

        }
        [Fact]
        public async Task DeleteFeedback_ShouldReturnNotFound_WhenRecordNotFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _serviceMock.Setup(x => x.DeleteFeedbackAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _sut.DeleteFeedback(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
        }
        [Fact]
        public async Task DeleteFeedback_ShouldReturnBadResponse_WhenInputIsZero()
        {
            // Arrange
            int id = 0;
            _serviceMock.Setup(x => x.DeleteFeedbackAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _sut.DeleteFeedback(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.DeleteFeedbackAsync(id), Times.Never());
        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnBadResponse_WhenInputIsZero()
        {
            // Arrange
            int id = 0;
            var request = _fixture.Create<FeedbackDTO>();

            // Act
            var result = await _sut.UpdateFeedback(id, request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnBadResponse_WhenInvalidRequest()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var request = _fixture.Create<FeedbackDTO>();
            _sut.ModelState.AddModelError("Subject", "The Subject field is required.");
            var response = _fixture.Create<FeedbackDTO>();
            _serviceMock.Setup(x => x.UpdateFeedbackAsync(id, request)).ReturnsAsync(false);


            // Act
            var result = await _sut.UpdateFeedback(id, request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BadRequestResult>();
            _serviceMock.Verify(x => x.UpdateFeedbackAsync(id, request), Times.Never());
        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnOkResponse_WhenRecordIsUpdated()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var request = _fixture.Create<FeedbackDTO>();
            _serviceMock.Setup(x => x.UpdateFeedbackAsync(id, request)).ReturnsAsync(true);

            // Act
            var result = await _sut.UpdateFeedback(id, request).ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<OkObjectResult>();
            _serviceMock.Verify(x => x.UpdateFeedbackAsync(id, request), Times.Once());

        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnNotFound_WhenRecordNotFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var request = _fixture.Create<FeedbackDTO>();
            _serviceMock.Setup(x => x.UpdateFeedbackAsync(id, request)).ReturnsAsync(false);

            // Act
            var result = await _sut.UpdateFeedback(id, request).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NotFoundResult>();
            _serviceMock.Verify(x => x.UpdateFeedbackAsync(id, request), Times.Once());
        }
        [Fact]
        public async Task TestMethodName_WhatshouldHappens_WhenScenario()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}