using CC.DataServices.Services.Interfaces;
using CC.Shared;
using CC.Shared.Abstractions;
using CC.Shared.Entities.CurrencyAPIEntities;
using CC.Shared.ExtAPIEntities;
using CC.Shared.Helpers;

using Flurl.Http.Configuration;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.Services
{
    public class CurrencyService : BaseAPIServices, ICurrencyService
    {
        private readonly int SLIDING_CACHE_INTERVAL_IN_SECONDS = 30;
        private readonly int ABSOLUTE_CACHE_INTERVAL_IN_SECONDS = 2 * 60;
        private readonly int MAX_RETRIES = 3;
        public CurrencyService(ILogger<CurrencyService> logger, IFlurlClientCache clients, CacheHelper cacheHelper) : base(logger, clients, "FrankfurterAPI", cacheHelper)
        {
        }

        public async Task<CurrencyEntity> GetLatestRatesAsync(string from)
        {
            var response = await GetRequestDataAsync<CurrencyEntity>(
                    $"/latest", 
                    MAX_RETRIES, 
                    SLIDING_CACHE_INTERVAL_IN_SECONDS, 
                    ABSOLUTE_CACHE_INTERVAL_IN_SECONDS, 
                    $"GetLatestRatesAsync_{from}", 
                    new Dictionary<string, string>
                    {
                        {"from", from }
                    }
                );

            return response;
        }

        public async Task<CurrencyEntity> ConvertCurrencyAsync(string from, string to, double amount)
        {
            var response = await GetRequestDataAsync<CurrencyEntity>(
                    $"/latest", 
                    MAX_RETRIES, 
                    SLIDING_CACHE_INTERVAL_IN_SECONDS, 
                    ABSOLUTE_CACHE_INTERVAL_IN_SECONDS, 
                    $"ConvertCurrencyAsync_{from}_{to}_{amount}", 
                    new Dictionary<string, string>
                    {
                        {"from", from },
                        {"to", to },
                        {"amount", amount.ToString() }
                    }
                );

            return response;
        }

        public async Task<CurrencyHistoricalEntity> GetHistoricalRatesAsync(string from, DateTime startDate, DateTime? endDate, int page, int pageSize)
        {
            string fromDate = startDate.GetDateString();
            string toDate = endDate.HasValue ? endDate.Value.GetDateString() : string.Empty;

            var response = await GetRequestDataAsync<CurrencyHistoricalEntity>(
                    $"/{fromDate}..{toDate}", 
                    MAX_RETRIES, SLIDING_CACHE_INTERVAL_IN_SECONDS, 
                    ABSOLUTE_CACHE_INTERVAL_IN_SECONDS, 
                    $"GetHistoricalRatesAsync_{from}_{fromDate}_{startDate}_{page}_{pageSize}", 
                    new Dictionary<string, string>
                    {
                        {"from", from }
                    }
                );

            response.HistoricalRates = response.HistoricalRates.Skip((page - 1) * pageSize).Take(pageSize).ToDictionary(x => x.Key, x => x.Value);

            return response;
        }
        
    }

}
