namespace RMT_API.Services
{
	public interface IBlobStorageService
	{
		Task<string> UploadFileAsync(string fileName, Stream fileStream);
		Task<Stream> DownloadFileAsync(string fileName);
	}
}
