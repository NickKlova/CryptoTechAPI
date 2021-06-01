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
    public class AccountController : ControllerBase
    {
        [HttpGet("info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromHeader] string ApiKEY, [FromHeader] string SecretKEY)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);

            BinanceAPI.HTTP.Response.AccountResponse.Account result;
            try
            {
                result = await client.GetAccountAsync();
                if(result == null)
                {
                    throw new Exception("Invalid data!");
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
