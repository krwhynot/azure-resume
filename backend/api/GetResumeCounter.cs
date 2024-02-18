using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace VisitorCounter.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static  HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,


            [CosmosDB(
                databaseName: "AzureResume",
                containerName: "Counter",
                Connection = "CosmosDBConnectionString",
                Id = "1",
                PartitionKey = "1")] Counter counter,
            [CosmosDB(
                databaseName: "AzureResume",
                containerName: "Counter",
                Connection = "CosmosDBConnectionString",
                Id = "1",
                PartitionKey ="11")] out Counter updatedCounter,
            ILogger log)
        {
            // Here is where the counter is updated. KR
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count++;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
