using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Text;

namespace PeajesFunction
{
    public static class PeajesFunction
    {

        [FunctionName("PeajesFunction")]
        //// 0 */5 * * * * /// every 5 minutes
        //// 0 0 0 1 1 * /// every 1/1 of the year
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(context.FunctionAppDirectory)
                        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .Build();

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            DownloadFileFromBlob(config);
        }

        private async static void DownloadFileFromBlob(IConfigurationRoot config)
        {
            try
            {
                var _config = config.GetType();
                string containername = config["blobContainer"].ToString();
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(config["StorageConnectionString"].ToString());
                string nameFile = config["FileName"].ToString();
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containername);

                CloudBlockBlob blob = container.GetBlockBlobReference(nameFile);

                Stream blobStream = await blob.OpenReadAsync();
                using (StreamReader reader = new StreamReader(blobStream, Encoding.UTF8))
                {
                    string JsonData = reader.ReadToEnd();
                    UpdateTolls(JsonData);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void UpdateTolls(string dataJson)
        {

            try
            {

            }
            catch(Exception ex){

            }
        }
    }
}
