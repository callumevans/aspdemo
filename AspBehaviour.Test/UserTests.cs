using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AspBehaviour.Models;
using Newtonsoft.Json;
using Xunit;

namespace AspBehaviour.Test
{
    public class UserTests : IClassFixture<TestApplicationFactory>
    {
        private readonly TestApplicationFactory factory;

        public UserTests(TestApplicationFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_ReturnsAllUsers()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync("/users");

            // Assert
            response.EnsureSuccessStatusCode();

            var users = JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());
            
            Assert.Equal(DatabaseSeeding.Users[0].Name, users[0].Name);
            Assert.Equal(DatabaseSeeding.Users[1].Name, users[1].Name);
        }

        [Fact]
        public async Task Post_CreatesAUser()
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.PostAsync("/users", new FormUrlEncodedContent(new []
            {
                new KeyValuePair<string, string>("Name", "Fred Fuchs"), 
            }));

            // Assert
            response.EnsureSuccessStatusCode();

            var created = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
            
            Assert.Equal("Fred Fuchs", created.Name);
        }
    }
}