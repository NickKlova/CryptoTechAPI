using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Clients
{
    public interface IDynamoDbClient
    {
        public Task<UsernameDbRepository> GetDataByUsername(string username);
        public Task PostDataToDb(Models.UsernameDbRepository account);
        public Task UpdateDataIntoDb(Models.UsernameDbRepository data);
    }
}
