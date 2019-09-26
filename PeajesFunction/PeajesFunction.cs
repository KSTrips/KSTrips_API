using System;
using System.Runtime.InteropServices;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace PeajesFunction
{
    public static class PeajesFunction
    {
        [FunctionName("PeajesFunction")]
        public static void Run([TimerTrigger("0 0 0 1 1 *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            DownloadFileFromBlob();
        }

        private static void DownloadFileFromBlob()
        {
            //// Create Reference to Azure Storage Account
            //string strorageconn = Microsoft.Extensions.Configuration..AppSettings.Get("StorageConnectionString");
            //CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);

            ////Create Reference to Azure Blob
            //CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //CloudBlobContainer container = blobClient.GetContainerReference("democontainer");


            ////The next 6 lines download the file test.txt with the name test.txt from the container "democontainer"
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference("DemoBlob");
            //using (var filestream = System.IO.File.OpenWrite(@"D:\Azure Storage Demo\Download\test.txt"))
            //{
            //    blockBlob.DownloadToStream(filestream);

            //}
        }
    }
}
