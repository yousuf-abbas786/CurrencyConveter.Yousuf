using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CC.Shared.CurrencyAPIEntities
{
    public class CurrencyHistoricalEntity
    {
        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, double>> HistoricalRates { get; set; }
    }
}
