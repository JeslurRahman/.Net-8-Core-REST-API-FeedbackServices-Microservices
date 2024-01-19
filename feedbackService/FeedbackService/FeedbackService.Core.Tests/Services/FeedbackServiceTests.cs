using AutoFixture;
using FeedbackService.Core.Interfaces.Repositories;
using FeedbackService.Core.Models;
using FeedbackService.Core.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace FeedbackService.Core.Tests
{
    public class FeedbackServiceTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IFeedbackRepository> _repositoryMock;
        private readonly Mock<ILogger<FeedbacksService>> _loggerMock;
        private readonly FeedbacksService _sut;
        public FeedbackServiceTests()
        {
            _fixture = new Fixture();
            _repositoryMock = _fixture.Freeze<Mock<IFeedbackRepository>>();
            _loggerMock = _fixture.Freeze<Mock<ILogger<FeedbacksService>>>();
            _sut = new FeedbacksService(_repositoryMock.Object, _loggerMock.Object);
        }
        [Fact]
        public void FeedbacksServiceConstructor_ShouldReturnNullReferenceException_WhenRepositoryIsNull()
        {
            // Arrange
            IFeedbackRepository feedbackRepository = null;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new FeedbacksService(feedbackRepository, _loggerMock.Object));
        }

        [Fact]
        public void FeedbacksServiceConstructor_ShouldReturnNullReferenceException_WhenLoggerIsNull()
        {
            // Arrange            
            ILogger<FeedbacksService> logger = null;

            // Act && Assert
            Assert.Throws<ArgumentNullException>(() => new FeedbacksService(_repositoryMock.Object, logger));
        }

        [Fact]
        public async Task GetAllFeedbacks_ShouldReturnData_WhenDataFound()
        {
            // Arrange
            var feedbacksMock = _fixture.Create<IEnumerable<FeedbackDTO>>();
            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(feedbacksMock);

            // Act
            var result = await _sut.GetAllFeedbacksAsync().ConfigureAwait(false);

            // Assert
            //Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<FeedbackDTO>>();
            _repositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
        [Fact]
        public async Task GetAllFeedbacks_ShouldReturnNull_WhenDataNotFound()
        {
            // Arrange
            IEnumerable<FeedbackDTO> feedbacksMock = null;
            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(feedbacksMock);

            // Act
            var result = await _sut.GetAllFeedbacksAsync().ConfigureAwait(false);

            // Assert
            result.Should().BeNull();
            _repositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnData_WhenDataFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var feedbacksMock = _fixture.Create<FeedbackDTO>();
            _repositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(feedbacksMock);

            // Act
            var result = await _sut.GetFeedbackByIdAsync(id).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<FeedbackDTO>();
            _repositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once());
        }
        [Fact]
        public async Task GetFeedbackById_ShouldReturnNull_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            FeedbackDTO feedbackMock = null;
            _repositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(feedbackMock);

            // Act
            var result = await _sut.GetFeedbackByIdAsync(id).ConfigureAwait(false);

            // Assert            
            result.Should().BeNull();
            _repositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once());
        }
        [Fact]
        public void GetFeedbackById_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            FeedbackDTO feedback = null; ;
            var id = 0;
            _repositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(feedback);

            // Act
            Func<FeedbackDTO> result = () => _sut.GetFeedbackByIdAsync(id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public async Task CreateFeedback_ShouldReturnData_WhenDataIsInsertedSucessfully()
        {
            // Arrange
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            _repositoryMock.Setup(x => x.CreateAsync(feedbackMock)).ReturnsAsync(feedbackMock);

            // Act
            var result = await _sut.CreateFeedbackAsync(feedbackMock).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<FeedbackDTO>();
            _repositoryMock.Verify(x => x.CreateAsync(feedbackMock), Times.Once());
        }
        [Fact]
        public void CreateFeedback_ShouldThrowNullReferenceException_WhenInputIsNull()
        {
            // Arrange
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            FeedbackDTO request = null;
            _repositoryMock.Setup(x => x.CreateAsync(feedbackMock)).ReturnsAsync(feedbackMock);

            // Act
            Func<FeedbackDTO> result = () => _sut.CreateFeedbackAsync(request).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public async Task DeleteFeedback_ShouldReturnTrue_WhenDataIsDeletedSuccessfully()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _repositoryMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(true);

            // Act
            var result = await _sut.DeleteFeedbackAsync(id).ConfigureAwait(false);

            // Assert
            result.Should().BeTrue();
            _repositoryMock.Verify(x => x.DeleteAsync(id), Times.Once());
        }
        [Fact]
        public async Task DeleteFeedback_ShouldReturnFalse_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            _repositoryMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _sut.DeleteFeedbackAsync(id).ConfigureAwait(false);

            // Assert
            result.Should().BeFalse();
            _repositoryMock.Verify(x => x.DeleteAsync(id), Times.Once());
        }
        [Fact]
        public void DeleteFeedback_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            var response = _fixture.Create<bool>();
            var id = 0;
            _repositoryMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(response);

            // Act
            Func<bool> result = () => _sut.DeleteFeedbackAsync(id).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnTrue_WhenDataUpdatedSucessfully()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            _repositoryMock.Setup(x => x.UpdateAsync(id, feedbackMock)).ReturnsAsync(true);

            // Act
            var result = await _sut.UpdateFeedbackAsync(id, feedbackMock).ConfigureAwait(false);

            // Assert
            result.Should().BeTrue();
            _repositoryMock.Verify(x => x.UpdateAsync(id, feedbackMock), Times.Once());
        }
        [Fact]
        public async Task UpdateFeedback_ShouldReturnFalse_WhenDataNotFound()
        {
            // Arrange
            var id = _fixture.Create<int>();
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            _repositoryMock.Setup(x => x.UpdateAsync(id, feedbackMock)).ReturnsAsync(false);

            // Act
            var result = await _sut.UpdateFeedbackAsync(id, feedbackMock).ConfigureAwait(false);

            // Assert
            result.Should().BeFalse();
            _repositoryMock.Verify(x => x.UpdateAsync(id, feedbackMock), Times.Once());
        }
        [Fact]
        public void UpdateFeedback_ShouldThrowNullReferenceException_WhenInputIsEqualsZero()
        {
            // Arrange
            var id = 0;
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            _repositoryMock.Setup(x => x.UpdateAsync(id, feedbackMock)).ReturnsAsync(false);

            // Act
            Func<bool> result = () => _sut.UpdateFeedbackAsync(id, feedbackMock).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void UpdateFeedback_ShouldThrowNullReferenceException_WhenRequestIsNull()
        {
            // Arrange
            var id = 0;
            var feedbackMock = _fixture.Create<FeedbackDTO>();
            FeedbackDTO request = null;
            _repositoryMock.Setup(x => x.UpdateAsync(id, feedbackMock)).ReturnsAsync(false);

            // Act
            Func<bool> result = () => _sut.UpdateFeedbackAsync(id, request).Result;

            // Assert
            result.Should().Throw<ArgumentNullException>();
        }
    }
}