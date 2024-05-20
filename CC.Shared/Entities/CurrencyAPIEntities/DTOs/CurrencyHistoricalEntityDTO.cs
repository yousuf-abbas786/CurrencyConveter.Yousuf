using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.Entities.CurrencyAPIEntities.DTOs
{
    public class CurrencyHistoricalEntityDTO
    {
        public CurrencyHistoricalEntity currencyHistoricalEntity { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public long totalRecords { get; set; }
    }
}
