using System.Collections.Generic;
using System.Threading.Tasks;
using Asp.Controllers;
using Asp.Interfaces;
using Asp.Models;
using Moq;
using Xunit;

namespace Asp.Test
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> userServiceMock;
        private readonly Mock<ICreateUserRequestMapper> createUserRequestMapperMock;
        private readonly UsersController usersController;

        public UserControllerTests()
        {
            userServiceMock = new Mock<IUserService>();
            createUserRequestMapperMock = new Mock<ICreateUserRequestMapper>();
            usersController = new UsersController(userServiceMock.Object, createUserRequestMapperMock.Object);
        }
        
        [Fact]
        public async Task When_GetUsers_ReturnsResultFromUserService()
        {
            // Arrange
            var users = new List<User>()
            {
                new User
                {
                    Name = "Test Result"
                }
            };

            userServiceMock
                .Setup(x => x.GetUsers())
                .ReturnsAsync(users);

            // Act
            var response = await usersController.Get();

            // Assert
            Assert.Equal("Test Result", response[0].Name);
        }
        
        [Fact]
        public async Task When_PostUser_CallsUserServiceWithMapperResult()
        {
            // Arrange
            var createUserRequest = new CreateUser
            {
                Name = "Request"
            };
            
            var userMapperResult = new User
            {
                Name = "Mapped"
            };

            createUserRequestMapperMock
                .Setup(x => x.MapToUser(createUserRequest))
                .Returns(userMapperResult);

            // Act
            await usersController.Post(createUserRequest);

            // Assert
            userServiceMock.Verify(x => x.CreateUser(userMapperResult), Times.Once);
        }
        
        [Fact]
        public async Task When_PostUser_ReturnsResultFromUserService()
        {
            // Arrange
            var userCreated = new User
            {
                Name = "Created User"
            };

            userServiceMock
                .Setup(x => x.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(userCreated);
            
            // Act
            var response = await usersController.Post(new CreateUser());

            // Assert
            Assert.Equal(userCreated, response);
        }
    }
}