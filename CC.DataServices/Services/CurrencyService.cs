using CC.DataServices.ExtAPIs;
using CC.Shared.Abstractions;
using CC.Shared.CurrencyAPIEntities;
using CC.Shared.ExtAPIEntities;

using Flurl.Http.Configuration;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CC.DataServices.ExtAPIs.LiveKubeAPIServices;

namespace CC.DataServices.Services
{
    public class CurrencyService : BaseAPIServices, ICurrencyService
    {
        public CurrencyService(ILogger<CurrencyService> logger, IFlurlClientCache clients) : base(logger, clients, "FrankfurterAPI")
        {
        }

        public async Task<CurrencyEntity> ConvertCurrency(string from, string to, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrencyEntity> GetHistoricalRates(string from, string startDate, string endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrencyEntity> GetLatestRates(string from)
        {
            var response = await GetRequestData<CurrencyEntity>($"/latest", null, new Dictionary<string, string>
            {
                {"from", from.ToString() }
            });

            return response;
        }
        
    }

}
