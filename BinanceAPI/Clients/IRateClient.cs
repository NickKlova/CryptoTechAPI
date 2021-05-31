using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Clients
{
    internal interface IRateClient
    {
        public Task<HTTP.Response.DailyRateResponse.DailyRate> GetDailyRateAsync(string symbol);
    }
}
