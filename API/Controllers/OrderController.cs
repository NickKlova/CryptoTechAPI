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
    public class OrderController : ControllerBase
    {
        [HttpGet("getinfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromHeader] string ApiKEY, [FromHeader] string SecretKEY, [FromQuery]string symbol, [FromQuery]long orderId)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.GetOrderReponse result;
            try
            {
                result = await client.GetOrderAsync(symbol, orderId);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getinfo/all/open")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllOpen([FromHeader] string ApiKEY, [FromHeader] string SecretKEY)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.GetOrderReponse[] result;
            try
            {
                result = await client.GetAllOpenOrderAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getinfo/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromHeader] string ApiKEY, [FromHeader] string SecretKEY, [FromQuery]string symbol)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.GetOrderReponse[] result;
            try
            {
                result = await client.GetAllOrderAsync(symbol);
                if(result == null)
                {
                    throw new Exception("Incorrect symbol!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromHeader] string ApiKEY, [FromHeader] string SecretKEY, [FromBody] JsonRequest.Order json)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.CreateOrderResponse result;
            try
            {
                if(json.side == "BUY")
                {
                    result = await client.CreateOrderAsync(json.symbol, BinanceAPI.Enums.Side.BUY, json.quoteOrderQty);
                    if (result.symbol == null || result.status == null)
                    {
                        throw new Exception("Parameters entered incorrectly!");
                    }
                }
                else if(json.side == "SELL")
                {
                    result = await client.CreateOrderAsync(json.symbol, BinanceAPI.Enums.Side.SELL, json.quoteOrderQty);
                    if (result.symbol == null || result.status == null)
                    {
                        throw new Exception("Parameters entered incorrectly!");
                    }
                }
                else
                {
                    throw new Exception("The type is not specified correctly!");
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest("Check if the parameters are entered correctly! Detail:\n" + e.Message);
            }
        }

        [HttpDelete("cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Cancel([FromHeader] string ApiKEY, [FromHeader] string SecretKEY, [FromQuery] string symbol, [FromQuery] long orderId)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.DeleteOrderReponse result;
            try
            {
                result = await client.DeleteOrderAsync(symbol, orderId);
                if (result.symbol == null || result.type == null)
                {
                    throw new Exception("Parameters entered incorrectly!");
                }
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("cancel/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelAll([FromHeader] string ApiKEY, [FromHeader] string SecretKEY, [FromQuery] string symbol)
        {
            BinanceClient client = new BinanceClient(ApiKEY, SecretKEY);
            BinanceAPI.HTTP.Response.DeleteOrderReponse[] result;
            try
            {
                result = await client.DeleteAllOpenOrderAsync(symbol);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
