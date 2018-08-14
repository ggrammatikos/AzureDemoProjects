using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageBlobDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create Reference to Azure Storage Account
            String strorageconn = System.Configuration.ConfigurationSettings.AppSettings.Get("StorageConnectionString");
            CloudStorageAccount storageacc = CloudStorageAccount.Parse(strorageconn);

            //Create Reference to Azure Blob
            CloudBlobClient blobClient = storageacc.CreateCloudBlobClient();

            //The next 2 lines create if not exists a container named "democontainer"
            CloudBlobContainer container = blobClient.GetContainerReference("democontainer");

            container.CreateIfNotExists();

            //The next 7 lines upload the file test.txt with the name DemoBlob on the container "democontainer"
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference("DemoBlob");
            //using (var filestream = System.IO.File.OpenRead(@"D:\Azure Storage Demo\test.txt"))
            //{

            //    blockBlob.UploadFromStream(filestream);

            // }

            //The next 6 lines download the file test.txt with the name test.txt from the container "democontainer"
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("DemoBlob");
            using (var filestream = System.IO.File.OpenWrite(@"D:\Azure Storage Demo\Download\test.txt"))
            {
                blockBlob.DownloadToStream(filestream);

            }

        }
    }
}
