using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.HTTP.Response
{
    public class GetOrderReponse
    {
        public string symbol { get; set; }
        public long orderId { get; set; }
        public string clientOrderId { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string side { get; set; }
        public decimal stopPrice { get; set; }
        public bool isWorking { get; set; }
    }
}
