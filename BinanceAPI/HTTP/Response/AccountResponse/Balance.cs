using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.HTTP.Response.AccountResponse
{
    public class Balance
    {
        public string asset { get; set; }
        public decimal free { get; set; }
        public decimal locked { get; set; }
    }
}
