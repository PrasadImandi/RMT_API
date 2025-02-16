using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegionsController(IRegionService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllRegions()
		{
			var Regions = await _service.GetAllRegionsAsync();
			return Ok(Regions);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetRegion(int id)
		{
			var Region = await _service.GetRegionByIdAsync(id);
			if (Region == null)
			{
				return NotFound();
			}

			return Ok(Region);
		}

		[HttpPost]
		public async Task<IActionResult> CreateRegion([FromBody] RegionDto Region)
		{
			if (Region == null)
			{
				return BadRequest("Region data is null.");
			}

			await _service.AddRegionAsync(Region);

			return CreatedAtAction(nameof(GetRegion), new { id = Region.ID }, Region);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateRegion(int id, [FromBody] RegionDto Region)
		{
			if (id != Region.ID)
			{
				return BadRequest("Region ID mismatch.");
			}

			await _service.UpdateRegionAsync(Region);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteRegion(int id)
		{
			await _service.DeleteRegionAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusRegion([FromBody] RegionDto Region)
		{
			await _service.ChangeStatusRegionAsync(Region);

			return NoContent();
		}
	}
}
