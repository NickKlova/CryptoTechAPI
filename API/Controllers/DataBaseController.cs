using API.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly ILogger<DataBaseController> _logger;
        private readonly IDynamoDbClient _dynamoDbClient;
        public DataBaseController(ILogger<DataBaseController> logger, IDynamoDbClient dynamoDbClient)
        {
            _logger = logger;
            _dynamoDbClient = dynamoDbClient;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDataFromDb([FromQuery] string username)
        {
            var result = await _dynamoDbClient.GetDataByUsername(username);

            if (result == null)
                return NotFound("Record doesn't exist in databse!");

            var accountResponse = new Models.UsernameDbRepository
            {
                Username = username,
                ApiKey = result.ApiKey,
                SecretKey = result.SecretKey
            };

            return Ok(accountResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddDataToDb([FromBody] Models.UsernameDbRepository account)
        {
            var data = new Models.UsernameDbRepository()
            {
                Username = account.Username,
                ApiKey = account.ApiKey,
                SecretKey = account.SecretKey
            };

            await _dynamoDbClient.PostDataToDb(account);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData([FromBody] Models.UsernameDbRepository data)
        {
            var datas = new Models.UsernameDbRepository()
            {
                Username = data.Username,
                ApiKey = data.ApiKey,
                SecretKey = data.SecretKey
            };

            await _dynamoDbClient.UpdateDataIntoDb(data);

            return Ok();
        }
    }
}
