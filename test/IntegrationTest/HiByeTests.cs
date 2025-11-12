using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace IntegrationTest
{
    public class HiByeTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Get_HelloWorld_ReturnsSuccessAndJson()
        {
            // Act
            var response = await _client.GetAsync("/api/HelloWorld/GetHelloWorld");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/plain; charset=utf-8",
                response.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Get_HelloWorld_ReturnsHelloWorldPhrase()
        {
            // Act
            var response = await _client.GetAsync("/api/HelloWorld/GetHelloWorld");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!", content);
        }


        [Fact]
        public async Task Get_GoodByeWorld_ReturnsSuccessAndJson()
        {
            // Act
            var response = await _client.GetAsync("/api/HelloWorld/GetGoodBye");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/plain; charset=utf-8",
                response.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Get_GoodByeWorld_ReturnsGoodByeWorldPhrase()
        {
            // Act
            var response = await _client.GetAsync("/api/HelloWorld/GetGoodBye");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("GoodBye World!", content);
        }
    }
}
