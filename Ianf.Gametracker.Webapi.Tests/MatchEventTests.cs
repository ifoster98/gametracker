using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Ianf.Gametracker.Webapi.Tests
{
    public class MatchEventTests
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "http://localhost";
        private readonly DateTime _currentTime = DateTime.Now;

        [Fact]
        public async System.Threading.Tasks.Task TestLoginWithValidUserId()
        {
            // Assemble
            var userId = 1234;
            var url = $"{_baseUrl}/LoginWithUserId/{userId}"; 

            // Act
            var result = await _client.GetAsync(url);

            // Assert
            result.EnsureSuccessStatusCode();
            var resultContent = await result.Content.ReadAsStringAsync();
            Assert.Equal("true", resultContent);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestLoginWithInvalidUserId()
        {
            // Assemble
            var userId = -1234;
            var url = $"{_baseUrl}/LoginWithUserId/{userId}"; 

            // Act
            var result = await _client.GetAsync(url);

            // Assert
            result.EnsureSuccessStatusCode();
            var resultContent = await result.Content.ReadAsStringAsync();
            Assert.Equal("false", resultContent);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestAddNewMatchEventAsync()
        {
            // Assemble
            var newMatchEvent = new Ianf.Gametracker.Services.Dto.MatchEvent() 
            {
                UserId = 1234,
                EventTime = DateTime.Now,
                MatchEventType = Services.MatchEventType.Conversion
            };
            var url = $"{_baseUrl}/MatchEvent"; 
            var body = JsonConvert.SerializeObject(newMatchEvent);
            var content = new StringContent(body,
                                    Encoding.UTF8, 
                                    "application/json");

            // Act
            var result = await _client.PostAsync(url, content);

            // Assert
            result.EnsureSuccessStatusCode();
            var resultContent = await result.Content.ReadAsStringAsync();
            Assert.Equal("1", resultContent);

            // Repeat to determine new id is generated
            result = await _client.PostAsync(url, content);
            result.EnsureSuccessStatusCode();
            resultContent = await result.Content.ReadAsStringAsync();
            Assert.Equal("2", resultContent);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestAddNewMatchEventAsyncInvalidUserId()
        {
            // Assemble
            var newMatchEvent = new Ianf.Gametracker.Services.Dto.MatchEvent() 
            {
                UserId = -1234,
                EventTime = DateTime.Now,
                MatchEventType = Services.MatchEventType.Conversion
            };
            var url = $"{_baseUrl}/MatchEvent"; 
            var body = JsonConvert.SerializeObject(newMatchEvent);
            var content = new StringContent(body,
                                    Encoding.UTF8, 
                                    "application/json");

            // Act
            var result = await _client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
