using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceAPI.Properties
{
    internal static class Config
    {
        internal static string ApiKey { get; set; }
        internal static string SecretKey { get; set; }
        internal static string BaseUrl { get; } = "https://api.binance.com";
    }
}
