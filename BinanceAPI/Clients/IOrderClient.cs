using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Clients
{
    internal interface IOrderClient
    {
        public Task<HTTP.Response.CreateOrderResponse> CreateOrderAsync(string symbol, Enums.Side side, decimal quoteOrderQty);
        public Task<HTTP.Response.DeleteOrderReponse> DeleteOrderAsync(string symbol, long orderId);
        public Task<HTTP.Response.DeleteOrderReponse[]> DeleteAllOpenOrderAsync(string symbol);
        public Task<HTTP.Response.GetOrderReponse> GetOrderAsync(string symbol, long orderId);
        public Task<HTTP.Response.GetOrderReponse[]> GetAllOpenOrderAsync();
        public Task<HTTP.Response.GetOrderReponse[]> GetAllOrderAsync(string symbol);
    }
}
