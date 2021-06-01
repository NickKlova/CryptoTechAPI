using BinanceAPI.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Entities
{
    internal static class Account
    {
        internal static async Task<HTTP.Response.AccountResponse.Account> GetAccount(HttpClient client)
        {
            string DataQueryString = $"recvWindow={60000}&timestamp={Tool.GenerateTimeStamp(DateTime.Now.ToUniversalTime())}";

            var signature = Tool.CreateHMACSignature(Config.SecretKey, DataQueryString);

            var response = await client.GetAsync($"{Config.BaseUrl}/api/v3/account?{DataQueryString}&signature={signature}");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                var json_response = JsonConvert.DeserializeObject<HTTP.Response.AccountResponse.Account>(content);

                return json_response;
            }
            else
            {
                return null;
            }
        }
    }
}
