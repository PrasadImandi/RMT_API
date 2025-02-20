using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class DashboardDetailsRepository(ApplicationDBContext context) : IDashboardDetailsRepository
	{
		public async Task<DashboardDetails> GetDashboardDetailsAsync()
		{
			DashboardDetails _dashboardDetails = new DashboardDetails();

			var totalResourceCount = await context.Resources.CountAsync();

			var activeResourcesCount = await context.Resources
									  .Where(x => x.IsActive == true)
									  .CountAsync();

			var inactiveResourcesCount = await context.Resources
									  .Where(x => x.IsActive == false)
									  .CountAsync();

			_dashboardDetails.ClientsCount = context.Clients.Where(x=>x.IsActive==true).Count();
			_dashboardDetails.ProjectsCount = context.Projects.Where(x=>x.IsActive==true).Count();
			_dashboardDetails.SuppliersCount = context.Supplier.Where(x=>x.IsActive==true).Count();

			_dashboardDetails.ClientProjects =await context.Clients
													.GroupJoin(context.Projects,
															   c => c.ID,
															   p => p.ClientID,
															   (c, projects) => new ClientDetails()
															   {
																   Name = c.Name,
																   ProjectsCount = projects.Count()
															   })
													.OrderByDescending(x=>x.ProjectsCount)
													.Take(3)
													.ToListAsync();

			ResourceCountDetails _countDetails = new()
			{
				ActiveResourceCount = activeResourcesCount,
				InactiveResourceCount = inactiveResourcesCount,
				TotalResourceCount = totalResourceCount
			};

			_dashboardDetails.ResourceCountDetails = _countDetails;

			var accountWiseResources = await context.Resources
									.Join(context.ResourceInformation,
										r => r.ID, ri => ri.ResourceID,
										(r, ri) => new { r, ri })
									.Join(context.ProfessionalDetails,
										rr => rr.ri.ID, pd => pd.ResourceInformationID,
										(rr, pd) => new { rr.r, pd })
									.Join(context.ResourceDeployments,
										rr => rr.r.ID, rd => rd.ResourceID,
										(rr, rd) => new { rr.r, rr.pd, rd })
									.Join(context.Projects,
										rrd => rrd.rd.ProjectID, p => p.ID,
										(rrd, p) => new { rrd.r, rrd.pd, rrd.rd, p })
									.Join(context.Clients,
										rp => rp.p.ClientID, c => c.ID,
										(rp, c) => new { rp.r, rp.pd, rp.rd, rp.p, c })
									.Where(x => x.rd.IsActive == true)
									.GroupBy(x => x.c.Name)
									.Select(g => new ClientDetails()
									{
										Name = g.Key,
										TotalResourceCount = g.Count(),
										ActiveResourceCount = g.Count(x => x.rd.IsActive == true),
										InactiveResourceCount = g.Count(x => x.rd.IsActive == false),
									}).ToListAsync();

			_dashboardDetails.ClientDetails = accountWiseResources;

			var projectWiseResources = await context.Resources
										.Join(context.ResourceInformation,
											r => r.ID, ri => ri.ResourceID,
											(r, ri) => new { r, ri })
										.Join(context.ProfessionalDetails,
											rr => rr.ri.ID, pd => pd.ResourceInformationID,
											(rr, pd) => new { rr.r, pd })
										.Join(context.ResourceDeployments,
											rr => rr.r.ID, rd => rd.ResourceID,
											(rr, rd) => new { rr.r, rr.pd, rd })
										.Join(context.Projects,
											rrd => rrd.rd.ProjectID, p => p.ID,
											(rrd, p) => new { rrd.r, rrd.pd, rrd.rd, p })
										.Where(x => x.rd.IsActive == true)
										.GroupBy(x => x.p.Name)
										.Select(g => new ProjectDetails()
										{
											Name = g.Key,
											TotalResourceCount = g.Count(),
											ActiveResourceCount = g.Count(x => x.rd.IsActive == true),
											InactiveResourceCount = g.Count(x => x.rd.IsActive == false)
										}).ToListAsync();

			_dashboardDetails.ProjectDetails = projectWiseResources;

			var supplierWiseResources = await context.Resources
										.Join(context.Supplier,
											r => r.SupplierID, s => s.ID,
											(r, s) => new { r, s })
										.Join(context.ResourceInformation,
											rs => rs.r.ID, ri => ri.ResourceID,
											(rs, ri) => new { rs.r, rs.s, ri })
										.Where(x => x.r.IsActive == true)
										.GroupBy(x => x.s.Name)
										.Select(g => new SupplierDetails()
										{
											Name = g.Key,
											TotalResourceCount = g.Count(),
											ActiveResourceCount = g.Count(x => x.r.IsActive == true),
											InactiveResourceCount = g.Count(x => x.r.IsActive == false)
										}).ToListAsync();


			_dashboardDetails.SupplierDetails = supplierWiseResources;

			//var inactiveResources = context.Resources
			//						.Join(context.ResourceInformation,
			//							r => r.ID, ri => ri.ResourceID,
			//							(r, ri) => new { r, ri })
			//						.Join(context.ProfessionalDetails,
			//							rr => rr.ri.ID, pd => pd.ResourceInformationID,
			//							(rr, pd) => new { rr.r, pd })
			//						.Where(x => x.r.IsActive == false && x.pd.LastWorkingDate >= DateTime.Now.AddMonths(-3) && x.pd.LastWorkingDate.Value.Year == DateTime.Now.Year)
			//						.GroupBy(x => x.pd.LastWorkingDate.Value.ToString("MMMM"))
			//						.Select(g => new
			//						{
			//							InactiveMonth = g.Key,
			//							AttritionCount = g.Count()
			//						}).ToList();


			//var activeResources = context.Resources
			//						.Join(context.ResourceInformation,
			//							r => r.ID, ri => ri.ResourceID,
			//							(r, ri) => new { r, ri })
			//						.Join(context.ProfessionalDetails,
			//							rr => rr.ri.ID, pd => pd.ResourceInformationID,
			//							(rr, pd) => new { rr.r, pd })
			//						.Where(x => x.r.IsActive == true && x.pd.JoiningDate >= DateTime.Now.AddMonths(-3) && x.pd.JoiningDate.Year == DateTime.Now.Year)
			//						.GroupBy(x => x.pd.JoiningDate.ToString("MMMM"))
			//						.Select(g => new
			//						{
			//							ActiveMonth = g.Key,
			//							GrowthCount = g.Count()
			//						}).ToList();


			var timesheetPendingApprovals = await context.Timesheet
								.Include(x => x.Resource)
								.Where(t => t.Status == "pending" && t.Resource.IsActive == true)
								.OrderBy(t => t.Created_Date)
								.Take(3)
								.Select(t => new TimesheetPendingApprovals()
								{
									Name = t.Resource.FirstName + " " + t.Resource.LastName,
									ResourceID = t.ResourceID,
									TimesheetID = t.ID,
									TimesheetCode = t.TimesheetCode,
									WeekStartDate = t.WeekStartDate,
									WeekEndDate = t.WeekEndDate,
								}).ToListAsync();

			_dashboardDetails.TimesheetPendings = timesheetPendingApprovals;

			return _dashboardDetails;
		}
	}
}
