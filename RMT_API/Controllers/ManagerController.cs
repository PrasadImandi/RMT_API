using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ManagerController(IManagerService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllManagers(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var Manager = await _service.GetAllManagersAsync(searchText, pageNumber, pageSize);
			return Ok(Manager);
		}

		[HttpGet("projectManagers/{projectId}")]
		public async Task<IActionResult> GetProjectManagersByProjectID(int projectId)
		{
			var Manager = await _service.GetProjectManagersByProjectIdAsync(projectId);
			return Ok(Manager);
		}

		[HttpGet("reportingManagers/{projectId}")]
		public async Task<IActionResult> GetReportingManagersByProjectID(int projectId)
		{
			var Manager = await _service.GetReportingManagersByProjectIdAsync(projectId);
			return Ok(Manager);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetManager(int id)
		{
			var Manager = await _service.GetManagerByIdAsync(id);
			if (Manager == null)
			{
				return NotFound();
			}

			return Ok(Manager);
		}

		[HttpPost]
		public async Task<IActionResult> CreateManager([FromBody] ManagerDto Manager)
		{
			if (Manager == null)
			{
				return BadRequest("Manager data is null.");
			}

			await _service.AddManagerAsync(Manager);

			return CreatedAtAction(nameof(GetManager), new { id = Manager.ID }, Manager);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateManager(int id, [FromBody] ManagerDto Manager)
		{
			if (id != Manager.ID)
			{
				return BadRequest("Manager ID mismatch.");
			}

			await _service.UpdateManagerAsync(Manager);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteManager(int id)
		{
			await _service.DeleteManagerAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusManager([FromBody] ManagerDto Manager)
		{
			await _service.ChangeStatusManagerAsync(Manager);

			return NoContent();
		}


	}
}
