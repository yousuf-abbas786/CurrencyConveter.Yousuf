﻿using CC.DataServices.Services.Interfaces;
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
        public CurrencyService(ILogger<CurrencyService> logger, IFlurlClientCache clients, CacheHelper cacheHelper) : base(logger, clients, "FrankfurterAPI", cacheHelper)
        {
        }

        public async Task<CurrencyEntity> GetLatestRatesAsync(string from)
        {
            var response = await GetRequestDataAsync<CurrencyEntity>($"/latest", new Dictionary<string, string>
            {
                {"from", from }
            });

            return response;
        }

        public async Task<CurrencyEntity> ConvertCurrencyAsync(string from, string to, double amount)
        {
            var response = await GetRequestDataAsync<CurrencyEntity>($"/latest", new Dictionary<string, string>
            {
                {"from", from },
                {"to", to },
                {"amount", amount.ToString() }
            });

            return response;
        }

        public async Task<CurrencyHistoricalEntity> GetHistoricalRatesAsync(string from, DateTime startDate, DateTime? endDate, int page, int pageSize)
        {
            var response = await GetRequestDataAsync<CurrencyHistoricalEntity>($"/{startDate.GetDateString()}..{(endDate.HasValue ? endDate.Value.GetDateString() : string.Empty) }", new Dictionary<string, string>
            {
                {"from", from }
            });

            response.HistoricalRates = response.HistoricalRates.Skip((page - 1) * pageSize).Take(pageSize).ToDictionary(x => x.Key, x => x.Value);

            return response;
        }
        
    }

}
