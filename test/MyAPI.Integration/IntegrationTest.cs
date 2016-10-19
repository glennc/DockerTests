using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyAPI.Integration
{
    public class IntegrationTest
    {
        private HttpClient _httpClient;
        public IntegrationTest()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public void CanGet200()
        {
            var test = _httpClient.GetAsync("http://myapi/api/values").Result;
            Assert.True(test.IsSuccessStatusCode);
        }

        [Fact]
        public void CanGetNewAPI()
        {
            var test = _httpClient.GetAsync("http://myapi/api/new").Result;
            Assert.True(test.IsSuccessStatusCode);
        }
    }
}
