using CC.Shared.Entities.CurrencyAPIEntities;
using CC.Shared.Models;

using Flurl.Http.Testing;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.OpenApi.Services;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CC.WebAPIs.Test
{
    public  class CurrencyServiceTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CurrencyServiceTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("https://localhost:15001") });
        }

        [Fact]
        public async Task GetLatestRates_ReturnsBaseEURByDefault()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "EUR";

            // Act
            var response = await _client.GetFromJsonAsync<APIResult>($"/api/Currencies/latest");

            // Assert
            Assert.NotNull(response.Data);
            var apiObject = JsonConvert.DeserializeObject<CurrencyEntity>(response.Data.ToString());
            Assert.Equal(baseCurrency, apiObject.Base);
        }
        [Fact]
        public async Task GetLatestRates_ReturnsLatestByBase()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "USD";
            DateTime currentDate = DateTime.Now;

            // Act
            var response = await _client.GetFromJsonAsync<APIResult>($"/api/Currencies/latest?from={baseCurrency}");

            // Assert
            Assert.NotNull(response.Data);
            var apiObject = JsonConvert.DeserializeObject<CurrencyEntity>(response.Data.ToString());
            Assert.InRange<DateTime>(Convert.ToDateTime(apiObject.Date), currentDate.AddDays(-3), currentDate.AddDays(1));
        }

        [Fact]
        public async Task GetLatestRates_ReturnsSpecificRates()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "USD";
            List<string> expectedRates = new List<string> { "EUR", "GBP" };

            // Act
            var response = await _client.GetFromJsonAsync<APIResult>($"/api/Currencies/latest?from={baseCurrency}&to=EUR,GBP");

            // Assert
            Assert.NotNull(response.Data);
            var apiObject = JsonConvert.DeserializeObject<CurrencyEntity>(response.Data.ToString());
            Assert.NotNull(apiObject.Rates);
            Assert.Equal(2, apiObject.Rates.Count);
            Assert.True(expectedRates.Contains(apiObject.Rates.Keys.First()) && expectedRates.Contains(apiObject.Rates.Keys.Last()));
        }

        //public async Task GetLatestRates_ReturnsBadRequestOnUnAvailableCurrency()
        //{
        //    using var httpTest = new HttpTest();

        //    // Arrange
        //    var baseCurrency = "USD";

        //    // Act
        //    var response = await _client.GetFromJsonAsync<APIResult>($"/api/Currencies/latest?from={baseCurrency}&to=TRY,GBP");

        //    // Assert
        //    //Assert.NotNull(response.Data);
        //    var apiObject = JsonConvert.DeserializeObject<CurrencyEntity>(response.Data.ToString());
        //    Assert.NotNull(apiObject.Rates);
        //    Assert.Equal(2, apiObject.Rates.Count);
        //    Assert.True(expectedRates.Contains(apiObject.Rates.Keys.First()) && expectedRates.Contains(apiObject.Rates.Keys.Last()));
        //}

    }
}
