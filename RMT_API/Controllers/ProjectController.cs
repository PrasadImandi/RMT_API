using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController(IProjectsService service) : ControllerBase
	{
		private readonly IProjectsService _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			var projects = await _service.GetAllProjectsAsync();
			return Ok(projects);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProject(int id)
		{
			var project = await _service.GetProjectByIdAsync(id);
			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProject([FromBody] ProjectDto project)
		{
			if (project == null)
			{
				return BadRequest("Project data is null.");
			}

			await _service.AddProjectAsync(project);

			return CreatedAtAction(nameof(GetProject), new { id = project.ID }, project);

		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDto project)
		{
			if (id != project.ID)
			{
				return BadRequest("Project ID mismatch.");
			}

			await _service.UpdateProjectAsync(project);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProject(int id)
		{
			await _service.DeleteProjectAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusProject([FromBody] ProjectDto project)
		{
			await _service.ChangeStatusProjectAsync(project);

			return NoContent();
		}
	}
}
