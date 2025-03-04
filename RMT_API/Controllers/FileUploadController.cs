using Microsoft.AspNetCore.Mvc;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : ControllerBase
	{
		private readonly string _storagePath = Path.Combine("D:", "UploadedFiles");
		public static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".pdf", ".docx", ".doc" };


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

			// Check if file extension is valid
			if (!IsValidFileType(file))
				return BadRequest("Invalid file type.");

			// Sanitize the file name
			var sanitizedFileName = SanitizeFileName(file.FileName);

			var filePath = Path.Combine(_storagePath, sanitizedFileName);

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

		// Delete a file
		[HttpDelete("delete/{filename}")]
		public IActionResult DeleteFile(string filename)
		{
			var filePath = Path.Combine(_storagePath, filename);
			if (!System.IO.File.Exists(filePath))
			{
				return NotFound();
			}

			System.IO.File.Delete(filePath);
			return NoContent();
		}

		// Update a file (delete old and upload new)
		[HttpPut("update/{filename}")]
		public async Task<IActionResult> UpdateFile(string filename, IFormFile file)
		{
			var filePath = Path.Combine(_storagePath, filename);
			if (!System.IO.File.Exists(filePath))
			{
				return NotFound();
			}

			// Delete old file
			System.IO.File.Delete(filePath);

			// Save the new file
			return await UploadFile(file);
		}

		private bool IsValidFileType(IFormFile file)
		{
			var extension = Path.GetExtension(file.FileName).ToLower();
			return AllowedExtensions.Contains(extension);
		}

		private string SanitizeFileName(string fileName)
		{
			// Remove unwanted characters
			var sanitizedFileName = Path.GetFileNameWithoutExtension(fileName);
			sanitizedFileName = new string(sanitizedFileName.Where(c => char.IsLetterOrDigit(c) || c == '-').ToArray());

			// Keep the original file extension
			var extension = Path.GetExtension(fileName).ToLower();
			return sanitizedFileName + extension;
		}
	}
}
