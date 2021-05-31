using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.JsonRequest
{
    public class Order
    {
        public string symbol { get; set; }
        public string side { get; set; }
        public decimal quoteOrderQty { get; set; }

    }
}
