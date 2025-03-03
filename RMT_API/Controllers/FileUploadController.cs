using Microsoft.AspNetCore.Mvc;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{
		private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

		public FileUploadController()
		{
			// Ensure the directory exists
			if (!Directory.Exists(_storagePath))
			{
				Directory.CreateDirectory(_storagePath);
			}
		}

		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("No file uploaded.");

			var filePath = Path.Combine(_storagePath, file.FileName);

			// Save file to disk
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Ok(new { FilePath = filePath });
		}

		[HttpGet("download/{fileName}")]
		public IActionResult DownloadFile(string fileName)
		{
			var filePath = Path.Combine(_storagePath, fileName);

			if (!System.IO.File.Exists(filePath))
				return NotFound();

			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			return File(fileBytes, "application/octet-stream", fileName);
		}
	}
}
