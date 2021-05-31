using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.HTTP.Response.AccountResponse
{
    public class Account
    {
        public bool canTrade { get; set; }
        public bool canWidthdraw { get; set; }
        public string accountType { get; set; }
        public Balance[] balances { get; set; }
    }
}
