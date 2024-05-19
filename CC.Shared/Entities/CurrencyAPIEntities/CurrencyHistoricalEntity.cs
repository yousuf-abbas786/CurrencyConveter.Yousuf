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
        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, double>> HistoricalRates { get; set; }

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public long TotalRecords { get; set; }
    }
}
