using BinanceAPI.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Entities
{
    internal static class Rate
    {
        public static async Task<HTTP.Response.DailyRateResponse.DailyRate> GetDailyRate(HttpClient client, string symbol)
        {
            string DataQueryString = $"symbol={symbol}";

            var response = await client.GetAsync($"{Config.BaseUrl}/api/v3/ticker/24hr?{DataQueryString}");

            var content = response.Content.ReadAsStringAsync().Result;

            var json_response = JsonConvert.DeserializeObject<HTTP.Response.DailyRateResponse.DailyRate>(content);

            return json_response;
        }
    }
}
