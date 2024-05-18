using CC.Shared.Entities.CurrencyAPIEntities;
using Flurl.Http.Testing;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace CC.WebAPIs.UnitTests
{
    public class CurrencyServiceTests : IClassFixture<WebApplicationFactory<TestEntryPoint>>
    {
        private readonly WebApplicationFactory<TestEntryPoint> _factory;
        private readonly HttpClient _client;

        public CurrencyServiceTests(WebApplicationFactory<TestEntryPoint> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetLatestRates_ReturnsRates()
        {
            using var flurlHttpTest = new HttpTest();

            // Arrange
            var from = "EUR";
            var expectedResponse = new CurrencyEntity
            {
                Base = from,
                Date = "2024-05-14",
                Rates = new Dictionary<string, double> { { "USD", 1.2 } }
            };
            flurlHttpTest.RespondWithJson(expectedResponse);

            // Act
            var response = await _client.GetFromJsonAsync<CurrencyEntity>($"/latest/{from}");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(from, response.Base);
            Assert.Equal(1.2, response.Rates["USD"]);
        }

        [Fact]
        public async Task ConvertCurrency_ThrowsException_ForExcludedCurrencies()
        {
            // Arrange
            var from = "TRY";
            var to = "USD";
            double amount = 100;

            // Act
            var response = await _client.GetAsync($"/convert?from={from}&to={to}&amount={amount}");

            // Assert
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ConvertCurrency_ReturnsConvertedAmount()
        {
            using var flurlHttpTest = new HttpTest();

            // Arrange
            var from = "EUR";
            var to = "USD";
            var amount = 100;
            var expectedResponse = new CurrencyEntity
            {
                Base = from,
                Date = "2024-05-14",
                Rates = new Dictionary<string, double> { { "USD", 1.2 } }
            };
            flurlHttpTest.RespondWithJson(expectedResponse);

            // Act
            var response = await _client.GetFromJsonAsync<CurrencyEntity>($"/convert?from={from}&to={to}&amount={amount}");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(from, response.Base);
            Assert.Equal(120, response.Rates["USD"]);
        }
    }
}
