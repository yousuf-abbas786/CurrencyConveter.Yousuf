using CC.Shared.CurrencyAPIEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.DataServices.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<CurrencyEntity> GetLatestRates(string from);
        Task<CurrencyEntity> ConvertCurrency(string from, string to, double amount);
        Task<CurrencyEntity> GetHistoricalRates(string from, string startDate, string endDate);
    }
}
