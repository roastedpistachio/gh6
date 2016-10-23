using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Data
{
    public static class ImportContainer
    {
        private static Lazy<CloudBlobContainer> _blobContainer = new Lazy<CloudBlobContainer>(() =>
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["BlobConnectionString"].ConnectionString);
            var cloudClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = cloudClient.GetContainerReference("import");
            blobContainer.CreateIfNotExists();
            return blobContainer;

        }, isThreadSafe: true);


        public async static Task<byte[]> GetFileAsync(string path)
        {
            var fileContent = default(byte[]);
            var file = _blobContainer.Value.GetBlobReference(path);

            if(await file.ExistsAsync())
            {
                using (var memoryStream = new MemoryStream())
                using(var streamReader = new StreamReader(memoryStream))
                {
                    await file.DownloadToStreamAsync(memoryStream);

                    fileContent = memoryStream.ToArray();
                }
            }

            return fileContent;
        }

        public async static Task AddFileAsync(string path, byte[] fileContent)
        {
            var file = _blobContainer.Value.GetBlockBlobReference(path);

            await file.UploadFromByteArrayAsync(fileContent, 0, fileContent.Length);
        }
    }
}