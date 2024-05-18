using CC.Shared.Entities.CurrencyAPIEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyEntity> GetLatestRatesAsync(string from);
        Task<CurrencyEntity> ConvertCurrencyAsync(string from, string to, double amount);
        Task<CurrencyHistoricalEntity> GetHistoricalRatesAsync(string from, DateTime startDate, DateTime? endDate, int page, int pageSize);
    }
}
