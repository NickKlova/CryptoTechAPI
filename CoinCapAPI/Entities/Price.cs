using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapAPI.Entities
{
    internal static class Price
    {
        internal async static Task<HTTP.Response.PriceInfoResponse> GetAllPriceInfo(HttpClient client, string symbol)
        {
            var response = await client.GetAsync($"https://api.coincap.io/v2/assets/{symbol}/markets");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.PriceInfoResponse>(content);

            return json_response;
        }
    }
}
