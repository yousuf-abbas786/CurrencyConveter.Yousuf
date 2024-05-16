using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.CurrencyAPIEntities
{
    public class CurrencyEntity
    {
        public float amount { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public Dictionary<object, Dictionary<object, object>> rates { get; set; }
    }
}
