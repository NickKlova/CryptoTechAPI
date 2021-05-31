using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BinanceAPI.Properties
{
    internal static class Tool
    {
        // Generate time for Binance request.
        public static string GenerateTimeStamp(DateTime baseDateTime)
        {
            var dtOffset = new DateTimeOffset(baseDateTime);
            return dtOffset.ToUnixTimeMilliseconds().ToString();
        }

        // Generate a string for signature in query string.
        public static string CreateHMACSignature(string key, string totalParams)
        {
            var messageBytes = Encoding.UTF8.GetBytes(totalParams);
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var hash = new HMACSHA256(keyBytes);
            var computedHash = hash.ComputeHash(messageBytes);
            return BitConverter.ToString(computedHash).Replace("-", "").ToLower();
        }
    }
}
