using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace RMT_API.Services
{
	public class BlobStorageService : IBlobStorageService
	{
		private readonly string _sasUrl;

		public BlobStorageService(string sasUrl)
		{
			_sasUrl = sasUrl;
		}

		// Upload a file to Blob Storage using SAS URL
		public async Task<string> UploadFileAsync(string fileName, Stream fileStream)
		{
			// Use the SAS URL to create the BlobClient
			var blobClient = new BlobClient(new Uri(_sasUrl));
			
			// Upload the file
			var blobContainerClient = blobClient.GetParentBlobContainerClient();
			var blobClientInstance = blobContainerClient.GetBlobClient(fileName);

			await blobClientInstance.UploadAsync(fileStream, overwrite: true);

			return blobClientInstance.Uri.ToString(); // Return file URL
		}

		// Download a file from Blob Storage using SAS URL
		public async Task<Stream> DownloadFileAsync(string fileName)
		{
			// Use the SAS URL to create the BlobClient
			var blobClient = new BlobClient(new Uri(_sasUrl));

			// Get the BlobClient for the specific file
			var blobContainerClient = blobClient.GetParentBlobContainerClient();
			var blobClientInstance = blobContainerClient.GetBlobClient(fileName);

			// Download the file
			var download = await blobClientInstance.DownloadAsync();
			return download.Value.Content;
		}
	}
}
