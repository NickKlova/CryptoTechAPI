using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapAPI.Clients
{
    internal interface IPriceClient
    {
        public Task<HTTP.Response.PriceInfoResponse> GetAllPriceInfo(string symbol);
    }
}
