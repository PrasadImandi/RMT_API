using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlobFileController(IBlobStorageService _blobStorageService) : ControllerBase
	{
		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return BadRequest("No file uploaded.");
			}

			using (var stream = file.OpenReadStream())
			{
				string fileUrl = await _blobStorageService.UploadFileAsync(file.FileName, stream);
				return Ok(new { FileUrl = fileUrl });
			}
		}

		[HttpGet("download/{fileName}")]
		public async Task<IActionResult> DownloadFile(string fileName)
		{
			var fileStream = await _blobStorageService.DownloadFileAsync(fileName);
			return File(fileStream, "application/octet-stream", fileName);
		}
	}
}
