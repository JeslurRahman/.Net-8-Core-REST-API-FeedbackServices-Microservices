using AutoFixture;
using FeedbackService.Core.Models;

namespace FeedbackService.Core.Tests.Models
{
    public class FeedbackDTOTests
    {
        public readonly IFixture fixture;
        public FeedbackDTOTests()
        {
            fixture = new Fixture();
        }
        [Fact]
        public void Id_ReturnAssignedValue()
        {
            // Arrange
            var id = fixture.Create<int>();

            // Act
            var sut = new FeedbackDTO
            {
                Id = id
            };

            // Assert
            Assert.Equal(id, sut.Id);
        }
        [Fact]
        public void Subject_ReturnAssignedValue()
        {
            // Arrange
            var subject = fixture.Create<string>();

            // Act
            var sut = new FeedbackDTO
            {
                Subject = subject
            };

            // Assert
            Assert.Equal(subject, sut.Subject);
        }
        [Fact]
        public void Message_ReturnAssignedValue()
        {
            // Arrange
            var message = fixture.Create<string>();

            // Act
            var sut = new FeedbackDTO
            {
                Message = message
            };

            // Assert
            Assert.Equal(message, sut.Message);
        }
        [Fact]
        public void Rating_ReturnAssignedValue()
        {
            // Arrange
            var rating = fixture.Create<int>();

            // Act
            var sut = new FeedbackDTO
            {
                Rating = rating
            };

            // Assert
            Assert.Equal(rating, sut.Rating);
        }
        [Fact]
        public void CreatedBy_ReturnAssignedValue()
        {
            // Arrange
            var createdBy = fixture.Create<string>();

            // Act
            var sut = new FeedbackDTO
            {
                CreatedBy = createdBy
            };

            // Assert
            Assert.Equal(createdBy, sut.CreatedBy);
        }
        [Fact]
        public void CreatedDate_ReturnAssignedValue()
        {
            // Arrange
            var createdDate = fixture.Create<DateTime>();

            // Act
            var sut = new FeedbackDTO
            {
                CreatedDate = createdDate
            };

            // Assert
            Assert.Equal(createdDate, sut.CreatedDate);
        }
    }
}