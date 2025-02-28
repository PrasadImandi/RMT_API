using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class ReportsRepository(ApplicationDBContext _context) : IReportsRepository
	{
		public async Task<IEnumerable<ClientReports>> GetClientReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0)
		{
			// Define the stored procedure call and pass parameters
			var filterTypeParam = filterType;  // Ensure we pass an empty string if null
			var searchNameParam = searchName;
			var pageNumberParam = pageNumber;
			var pageSizeParam = pageSize;

			// Using FromSqlRaw for executing the stored procedure
			var clientReports = await _context.ClientReports
				.FromSqlRaw("Exec SearchClientReports @FilterType = {0}, @SearchName  = {1}, @PageNumber  = {2}, @PageSize = {3} ",
					filterTypeParam, searchNameParam, pageNumberParam, pageSizeParam)
				.ToListAsync();

			return clientReports;
		}

		public async Task<IEnumerable<ResourceReports>> GetResourceReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0)
		{
			// Define the stored procedure call and pass parameters
			var filterTypeParam = filterType;  // Ensure we pass an empty string if null
			var searchNameParam = searchName;
			var pageNumberParam = pageNumber;
			var pageSizeParam = pageSize;

			// Using FromSqlRaw for executing the stored procedure
			var resourceReports = await _context.ResourceReports
				.FromSqlRaw("Exec SearchResourceReports @FilterType = {0}, @SearchTerm  = {1}, @PageNumber  = {2}, @PageSize = {3} ",
					filterTypeParam, searchNameParam, pageNumberParam, pageSizeParam)
				.ToListAsync();

			return resourceReports;
		}

		public async Task<IEnumerable<SupplierReports>> GetSupplierReportsAsync(string filterType = "", string searchName = "", int pageNumber = 0, int pageSize = 0)
		{
			// Define the stored procedure call and pass parameters
			var filterTypeParam = filterType;
			var searchNameParam = searchName;
			var pageNumberParam = pageNumber;
			var pageSizeParam = pageSize;

			// Using FromSqlRaw for executing the stored procedure
			var supplierReports = await _context.SupplierReports
				.FromSqlRaw("Exec SearchSupplierReports @FilterType = {0}, @SearchName  = {1}, @PageNumber  = {2}, @PageSize = {3} ",
					filterTypeParam, searchNameParam, pageNumberParam, pageSizeParam)
				.ToListAsync();

			return supplierReports;
		}
	}
}
