using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CC.Shared.Entities.CurrencyAPIEntities
{
    public class CurrencyHistoricalEntity
    {
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, double>> HistoricalRates { get; set; }


    }

    public class CurrencyHistoricalEntityDto
    {
        public CurrencyHistoricalEntity currencyHistoricalEntity { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public long totalRecords { get; set; }
    }
}
