using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cloud_app_func
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run(
            [BlobTrigger("items/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob
            , string name, ILogger log)
        {
            const string api = @"https://cloudapiagain.azurewebsites.net/Items";


            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");


            HttpClient client = new HttpClient();


            var it = new Item { ItemId = 0, Name = name, Timestamp = DateTime.Now };


            var response = await client.PostAsJsonAsync<Item>(api, it);
            ;
            var responseString = await response.Content.ReadAsStringAsync();
            log.LogInformation($"response: {responseString}");
        }
        private class Item

        {
            public int ItemId { get; set; }
            public string Name { get; set; }
            public DateTime Timestamp { get; set; }
        }


    }
}
