using BinanceAPI.Clients;
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
    public class RateController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDailyRate([FromHeader] string ApiKEY, [FromQuery]string symbol)
        {
            BinanceClient client = new BinanceClient(ApiKEY);
            BinanceAPI.HTTP.Response.DailyRateResponse.DailyRate result;
            try
            {
                result = await client.GetDailyRateAsync(symbol);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
