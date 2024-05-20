﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.Models
{
    public class APIPageResult : APIResult
    {
        public long TotalRecords { get; set; }

        public int PageNo { get; set; }

        public int PageSize { get; set; }
    }
}
