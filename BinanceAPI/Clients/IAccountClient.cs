using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BinanceAPI.Clients
{
    internal interface IAccountClient
    {
        public Task<HTTP.Response.AccountResponse.Account> GetAccountAsync();
    }
}
