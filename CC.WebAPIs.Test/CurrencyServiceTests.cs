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
using System.Text.Json;
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
            Assert.InRange<DateTime>(Convert.ToDateTime(apiObject.Date), currentDate.AddDays(-5), currentDate.AddDays(1));
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

        [Fact]
        public async Task GetLatestRates_ReturnsBadRequestOnUnAvailableCurrency()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "USD";

            // Act
            var response = await _client.GetFromJsonAsync<APIResult>($"/api/Currencies/latest?from={baseCurrency}&to=AED,FFF");

            // Assert
            Assert.True(response.StatusCode == 400);
            Assert.True(response.Message.Contains("not allowed") && response.Message.Contains("AED") && response.Message.Contains("FFF"));

        }

        [Fact]
        public async Task GetConvertedRates_ReturnsBadRequestOnNonAllowedCurrency()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "EUR";
            double amount = 10;

            // Act
            var response = await _client.GetAsync($"/api/Currencies/convert?from={baseCurrency}&to=THB,TRY&amount={amount}");

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task GetHistoricalRates_ReturnsInvalidDateFormat()
        {
            using var httpTest = new HttpTest();

            // Arrange
            var baseCurrency = "EUR";

            // Act
            var response = await _client.GetAsync($"/api/Currencies/historical?from={baseCurrency}&startDate=2023-31-01");

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);

        }

        [Fact]
        public async Task GetHistoricalRates_ReturnsCorrectPagination()
        {
            using var httpTest = new HttpTest();
            int page = 2;
            int pageSize = 20;

            // Arrange
            var baseCurrency = "EUR";

            // Act
            var response = await _client.GetFromJsonAsync<APIPageResult>($"/api/Currencies/historical?from={baseCurrency}&startDate=2023-01-01&endDate=2024-01-01&page={page}&pageSize={pageSize}");

            // Assert
            Assert.NotNull(response.Data);
            Assert.Equal(response.PageNo, page);
            Assert.Equal(response.PageSize, pageSize);

            var apiObject = JsonConvert.DeserializeObject<CurrencyHistoricalTestEntity>(response.Data.ToString());
            Assert.NotNull(apiObject.rates);
            Assert.Equal(apiObject.rates.Count, pageSize);

        }

    }
}
