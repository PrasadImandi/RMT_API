using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectBaselineController(IProjectBaseLineService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllProjectBaseLine(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var ProjectBaseLine = await _service.GetAllProjectBaseLinesAsync(searchText, pageNumber, pageSize);
			return Ok(ProjectBaseLine);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProjectBaseLine(int id)
		{
			var ProjectBaseLine = await _service.GetProjectBaseLineByIdAsync(id);
			if (ProjectBaseLine == null)
			{
				return NotFound();
			}

			return Ok(ProjectBaseLine);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProjectBaseLine([FromBody] ProjectBaseLineDto ProjectBaseLine)
		{
			if (ProjectBaseLine == null)
			{
				return BadRequest("ProjectBaseLine data is null.");
			}

			await _service.AddProjectBaseLineAsync(ProjectBaseLine);

			return CreatedAtAction(nameof(GetProjectBaseLine), new { id = ProjectBaseLine.ID }, ProjectBaseLine);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProjectBaseLine(int id, [FromBody] ProjectBaseLineDto ProjectBaseLine)
		{
			if (id != ProjectBaseLine.ID)
			{
				return BadRequest("ProjectBaseLine ID mismatch.");
			}

			await _service.UpdateProjectBaseLineAsync(ProjectBaseLine);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProjectBaseLine(int id)
		{
			await _service.DeleteProjectBaseLineAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusProjectBaseLine([FromBody] ProjectBaseLineDto ProjectBaseLine)
		{
			await _service.ChangeStatusProjectBaseLineAsync(ProjectBaseLine);

			return NoContent();
		}
	}
}
