using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CC.WebAPIs.Test
{
    public class CurrencyHistoricalTestEntity
    {
        public float amount { get; set; }

        public string @base { get; set; }

        public string start_date { get; set; }

        public string end_date { get; set; }

        public Dictionary<string, Dictionary<string, double>> rates { get; set; }


    }
}
