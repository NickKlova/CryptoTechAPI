using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.HTTP.Request
{
    public class CreateOrderRequest
    {
        public string symbol { get; set; }
        public Enums.Side side { get; set; }
        public Enums.Type type { get; } = Enums.Type.MARKET;
        public decimal quoteOrderQty { get; set; }
        public decimal timestamp { get; set; }
    }
}
