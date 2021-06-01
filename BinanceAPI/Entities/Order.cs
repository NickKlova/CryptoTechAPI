using BinanceAPI.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Entities
{
    internal static class Order
    {
        internal static async Task<HTTP.Response.CreateOrderResponse> CreateOrder(HttpClient client, string symbol, Enums.Side side, decimal quoteOrderQty)
        {
            var order = new HTTP.Request.CreateOrderRequest
            {
                symbol = symbol,
                side = side,
                quoteOrderQty = quoteOrderQty,
                timestamp = Convert.ToDecimal(Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime()))
            };

            var json = JsonConvert.SerializeObject(order);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            string DataQueryString = null;
            switch (side)
            {
                case Enums.Side.BUY:
                    DataQueryString = $"symbol={symbol}&side=BUY&type=MARKET&quoteOrderQty={quoteOrderQty}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";
                    break;
                case Enums.Side.SELL:
                    DataQueryString = $"symbol={symbol}&side=SELL&type=MARKET&quoteOrderQty={quoteOrderQty}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";
                    break;
            }

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.PostAsync($"{Config.BaseUrl}/api/v3/order?{DataQueryString}&signature={signature}", data);

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.CreateOrderResponse>(content);

            return json_response;
        }
        internal static async Task<HTTP.Response.DeleteOrderReponse[]> DeleteAllOpenOrder(HttpClient client, string symbol)
        {
            string DataQueryString = $"symbol={symbol}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.DeleteAsync($"{Config.BaseUrl}/api/v3/openOrders?{DataQueryString}&signature={signature}");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.DeleteOrderReponse[]>(content);

            return json_response;
        }
        internal static async Task<HTTP.Response.DeleteOrderReponse> DeleteOrder(HttpClient client, string symbol, decimal orderId)
        {
            string DataQueryString = $"symbol={symbol}&orderId={orderId}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.DeleteAsync($"{Config.BaseUrl}/api/v3/order?{DataQueryString}&signature={signature}");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.DeleteOrderReponse>(content);

            return json_response;
        }
        internal static async Task<HTTP.Response.GetOrderReponse> GetOrder(HttpClient client, string symbol, long orderId)
        {
            string DataQueryString = $"symbol={symbol}&orderId={orderId}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.GetAsync($"{Config.BaseUrl}/api/v3/order?{DataQueryString}&signature={signature}");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.GetOrderReponse>(content);

            return json_response;
        }
        internal static async Task<HTTP.Response.GetOrderReponse[]> GetAllOpenOrder(HttpClient client)
        {
            string DataQueryString = $"recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.GetAsync($"{Config.BaseUrl}/api/v3/openOrders?{DataQueryString}&signature={signature}");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.GetOrderReponse[]>(content);

            return json_response;
        }
        internal static async Task<HTTP.Response.GetOrderReponse[]> GetlAllOrder(HttpClient client, string symbol)
        {
            string DataQueryString = $"symbol={symbol}&recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.GetAsync($"{Config.BaseUrl}/api/v3/allOrders?{DataQueryString}&signature={signature}");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var json_response = JsonConvert.DeserializeObject<HTTP.Response.GetOrderReponse[]>(content);

                return json_response;
            }
            else
            {
                return null;
            }
        }
    }
}
