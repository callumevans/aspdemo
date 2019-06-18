using Asp.Models;
using Asp.Services;
using Xunit;

namespace Asp.Test
{
    public class CreateUserRequestMapperTests
    {
        private readonly CreateUserRequestMapper createUserRequestMapper;
        
        public CreateUserRequestMapperTests()
        {
            createUserRequestMapper = new CreateUserRequestMapper();
        }

        [Fact]
        public void MapRequest_ShouldReturnMappedUser()
        {
            // Arrange
            var requestInput = new CreateUser
            {
                Name = "My Test Name"
            };

            // Act
            var result = createUserRequestMapper.MapToUser(requestInput);

            // Assert
            Assert.Equal(requestInput.Name, result.Name);
        }
    }
}