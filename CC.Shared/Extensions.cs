using CC.Shared.Entities.CurrencyAPIEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared
{
    public static class Extensions
    {
        public static string GetDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static CurrencyHistoricalEntity Clone(this CurrencyHistoricalEntity currencyHistoricalEntity)
        {
            return new CurrencyHistoricalEntity
            {
                Amount = currencyHistoricalEntity.Amount,
                Base = currencyHistoricalEntity.Base,
                StartDate = currencyHistoricalEntity.StartDate,
                EndDate = currencyHistoricalEntity.EndDate,
                HistoricalRates = currencyHistoricalEntity.HistoricalRates
            };
        }
    }
}
