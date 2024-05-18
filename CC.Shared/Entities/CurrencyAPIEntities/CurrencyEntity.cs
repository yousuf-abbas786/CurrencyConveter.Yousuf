using Flurl.Http.Configuration;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CC.Shared.Entities.CurrencyAPIEntities
{
    public class CurrencyEntity
    {
        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }

}
