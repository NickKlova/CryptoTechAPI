using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.HTTP.Response
{
    public class DeleteOrderReponse
    {
        public string symbol { get; set; }
        public long orderId { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string side { get; set; }
    }
}
