using Microsoft.AspNetCore.Mvc;
using RMT_API.DTOs;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController(ISupplierService _service) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllSuppliers(string searchText = "", int pageNumber = 0, int pageSize = 10)
		{
			var suppliers = await _service.GetAllSuppliersAsync(searchText, pageNumber, pageSize);
			return Ok(suppliers);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSupplier(int id)
		{
			var supplier = await _service.GetSupplierByIdAsync(id);
			if (supplier == null)
			{
				return NotFound();
			}

			return Ok(supplier);
		}

		[HttpPost]
		public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto supplier)
		{
			if (supplier == null)
			{
				return BadRequest("Supplier data is null.");
			}

			await _service.AddSupplierAsync(supplier);

			return CreatedAtAction(nameof(GetSupplier), new { id = supplier.ID }, supplier);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierDto supplier)
		{
			if (id != supplier.ID)
			{
				return BadRequest("Supplier ID mismatch.");
			}

			await _service.UpdateSupplierAsync(supplier);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSupplier(int id)
		{
			await _service.DeleteSupplierAsync(id);

			return NoContent();
		}

		[HttpPatch]
		public async Task<IActionResult> ChangeStatusSupplier([FromBody] SupplierDto supplier)
		{
			await _service.ChangeStatusSupplierAsync(supplier);

			return NoContent();
		}
	}
}
