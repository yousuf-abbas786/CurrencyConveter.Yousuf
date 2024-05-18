using CC.DataServices.Services.Interfaces;
using CC.Shared;
using CC.Shared.Abstractions;
using CC.Shared.Entities.CurrencyAPIEntities;
using CC.Shared.ExtAPIEntities;

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
        public CurrencyService(ILogger<CurrencyService> logger, IFlurlClientCache clients) : base(logger, clients, "FrankfurterAPI")
        {
        }

        public async Task<CurrencyEntity> GetLatestRates(string from)
        {
            var response = await GetRequestData<CurrencyEntity>($"/latest", new Dictionary<string, string>
            {
                {"from", from }
            });

            return response;
        }

        public async Task<CurrencyEntity> ConvertCurrency(string from, string to, double amount)
        {
            var response = await GetRequestData<CurrencyEntity>($"/latest", new Dictionary<string, string>
            {
                {"from", from },
                {"to", to },
                {"amount", amount.ToString() }
            });

            return response;
        }

        public async Task<CurrencyHistoricalEntity> GetHistoricalRates(string from, DateTime startDate, DateTime? endDate, int page, int pageSize)
        {
            var response = await GetRequestData<CurrencyHistoricalEntity>($"/{startDate.GetDateString()}..{(endDate.HasValue ? endDate.Value.GetDateString() : string.Empty) }", new Dictionary<string, string>
            {
                {"from", from }
            });

            response.HistoricalRates = response.HistoricalRates.Skip((page - 1) * pageSize).Take(pageSize).ToDictionary(x => x.Key, x => x.Value);

            return response;
        }
        
    }

}
