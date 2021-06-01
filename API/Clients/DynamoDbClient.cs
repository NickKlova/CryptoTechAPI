using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using API.Extensions;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Clients
{
    public class DynamoDbClient : IDynamoDbClient
    {
        private string _tableName;
        private readonly IAmazonDynamoDB _dynamoDb;
        public DynamoDbClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDb = dynamoDB;
            _tableName = Properties.Config.TableName;
        }
        public async Task<UsernameDbRepository> GetDataByUsername(string username)
        {
            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "username", new AttributeValue { S = username } }
                }
            };

            var response = await _dynamoDb.GetItemAsync(item);

            if (response.Item == null || !response.IsItemSet)
                return null;

            var result = response.Item.ToClass<UsernameDbRepository>();

            return result;
        }

        public async Task UpdateDataIntoDb(Models.UsernameDbRepository data)
        {
            UpdateItemRequest updateRequest = new UpdateItemRequest()
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
          {
            { "username", new AttributeValue { S = data.Username } }
          },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>
          {
            { ":a", new AttributeValue { S = data.ApiKey } },
            { ":s", new AttributeValue { S = data.SecretKey } }
          },
                UpdateExpression = "SET ApiKey = :a, SecretKey = :s",
                ReturnValues = "NONE"
            };

            var response = await _dynamoDb.UpdateItemAsync(updateRequest);
        }

        public async Task PostDataToDb(Models.UsernameDbRepository data)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "username", new AttributeValue { S = data.Username } },
                    { "ApiKey", new AttributeValue { S = data.ApiKey } },
                    { "SecretKey", new AttributeValue { S = data.SecretKey } }
                }
            };

            var response = await _dynamoDb.PutItemAsync(request);
        }
    }
}
