using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangePriceController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExchangeInfo([FromQuery] string symbol)
        {
            CoinCapAPI.Clients.CoinCapClient client = new CoinCapAPI.Clients.CoinCapClient();
            CoinCapAPI.HTTP.Response.PriceInfoResponse result;

            try
            {
                result = await client.GetAllPriceInfo(symbol);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
