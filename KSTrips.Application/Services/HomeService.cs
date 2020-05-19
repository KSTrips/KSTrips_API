using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;

namespace KSTrips.Application.Services
{
    public class HomeService : IHomeService
    {
        private IConfiguration Iconfiguration;

        public HomeService(IConfiguration configuration)
        {
            Iconfiguration = configuration;
        }

        public Video GetPromotionalVideo()
        {
            Video result = DownloadFileFromBlob("KS_Trips_Marketing.mp4");

            return result;
        }

        public Video GetHowUseAppVideo()
        {
            Video result = DownloadFileFromBlob("KS_Trips_HowUseIt.mp4");

            return result;
        }
        private Video DownloadFileFromBlob(string namevideo)
        {
            try
            {
                var response = new Video();
                string containername = Iconfiguration.GetSection("blobContainer").Value;
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Iconfiguration.GetSection("StorageConnectionString").Value);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containername);

                CloudBlockBlob blob = container.GetBlockBlobReference(namevideo);
                //string sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                //{
                //    Permissions = SharedAccessBlobPermissions.Read,
                //    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1),//Set this date/time according to your requirements
                //});
                // string urlToBePlayed = string.Format("{0}{1}", blob.Uri, sas);//This is the URI which should be embedded in your video player.
                string urlToBePlayed = string.Format("{0}", blob.Uri);

                response.Url = urlToBePlayed;
                response.Name = namevideo;

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
