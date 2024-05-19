using CC.Shared.Entities.CurrencyAPIEntities;

using MongoDB.Bson.Serialization.IdGenerators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyEntity> GetLatestRatesAsync(string from, string to, double amount);
        Task<CurrencyHistoricalEntityDto> GetHistoricalRatesAsync(string from, string to, DateTime startDate, DateTime? endDate, int page, int pageSize);
        Task<Dictionary<string, string>> GetCurrencies();
    }
}
