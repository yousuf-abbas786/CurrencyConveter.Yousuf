using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.Models
{
    public class APIResult
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "Ok";
        public object Data { get; set; } = null;
    }

    public class APIPageResult :APIResult
    {
        public int TotalRecords { get; set; }

        public int PageNo { get; set; }

        public int PageSize { get; set; }
    }
}
