using Microsoft.AspNetCore.Mvc;
using RMT_API.Services;

namespace RMT_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController(IReportsService _reportService) : ControllerBase
	{

		[HttpGet("clients")]
		public async Task<IActionResult> GetAllClients(string filterType = "", string searchName = "", int pageNumber = 1, int pageSize = 10)
		{
			var clientReports = await _reportService.GetClientReportsAsync(filterType, searchName, pageNumber, pageSize);
			return Ok(clientReports);
		}

		[HttpGet("suppliers")]
		public async Task<IActionResult> GetAllSuppliers(string filterType = "", string searchName = "", int pageNumber = 1, int pageSize = 10)
		{
			var clients = await _reportService.GetSupplierReportsAsync(filterType, searchName, pageNumber, pageSize);
			return Ok(clients);
		}

		//[HttpGet("supplierContactMatrix")]
		//public async Task<IActionResult> GetAllSupplierContactMatrices()
		//{
		//	var clients = await _clientService.GetAllClientsAsync();
		//	return Ok(clients);
		//}

		[HttpGet("resources")]
		public async Task<IActionResult> GetResourceReportsAsync(string filterType = "", string searchName = "", int pageNumber = 1, int pageSize = 10)
		{
			var clients = await _reportService.GetResourceReportsAsync(filterType, searchName, pageNumber, pageSize);
			return Ok(clients);
		}

		[HttpGet("projects")]
		public async Task<IActionResult> GetProjectReportsAsync(string filterType = "", string searchName = "", int pageNumber = 1, int pageSize = 10)
		{
			var clients = await _reportService.GetProjectReportsAsync(filterType, searchName, pageNumber, pageSize);
			return Ok(clients);
		}
	}
}
