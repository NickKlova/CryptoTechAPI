using BinanceAPI.Properties;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Clients
{
    public class BinanceClient : IOrderClient, IAccountClient, IRateClient
    {
        private HttpClient _client;
        public BinanceClient(string akey, string skey = null)
        {
            Config.ApiKey = akey;
            Config.SecretKey = skey;

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.ApiKey);
        }
        #region Order
        public async Task<HTTP.Response.CreateOrderResponse> CreateOrderAsync(string symbol, Enums.Side side, decimal quoteOrderQty)
        {
            return await Entities.Order.CreateOrder(_client, symbol, side, quoteOrderQty);
        }

        public async Task<HTTP.Response.DeleteOrderReponse[]> DeleteAllOpenOrderAsync(string symbol)
        {
            return await Entities.Order.DeleteAllOpenOrder(_client, symbol);
        }

        public async Task<HTTP.Response.DeleteOrderReponse> DeleteOrderAsync(string symbol, long orderId)
        {
            return await Entities.Order.DeleteOrder(_client, symbol, orderId);
        }

        public async Task<HTTP.Response.GetOrderReponse[]> GetAllOpenOrderAsync()
        {
            return await Entities.Order.GetAllOpenOrder(_client);
        }

        public async Task<HTTP.Response.GetOrderReponse[]> GetAllOrderAsync(string symbol)
        {
            return await Entities.Order.GetlAllOrder(_client, symbol);
        }

        public async Task<HTTP.Response.GetOrderReponse> GetOrderAsync(string symbol, long orderId)
        {
            return await Entities.Order.GetOrder(_client, symbol, orderId);
        }
        #endregion

        #region Account
        public async Task<HTTP.Response.AccountResponse.Account> GetAccountAsync()
        {
            return await Entities.Account.GetAccount(_client);
        }
        #endregion

        #region Rate
        public async Task<HTTP.Response.DailyRateResponse.DailyRate> GetDailyRateAsync(string symbol)
        {
            return await Entities.Rate.GetDailyRate(_client, symbol);
        }
        #endregion
    }
}
