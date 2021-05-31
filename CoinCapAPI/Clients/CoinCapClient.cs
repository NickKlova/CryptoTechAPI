using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapAPI.Clients
{
    public class CoinCapClient : IPriceClient
    {
        private HttpClient _client;
        public CoinCapClient()
        {
            _client = new HttpClient();
        }
        public async Task<HTTP.Response.PriceInfoResponse> GetAllPriceInfo(string symbol)
        {
            return await Entities.Price.GetAllPriceInfo(_client, symbol);
        }
    }
}
