using Microsoft.EntityFrameworkCore;
using RMT_API.Models;


namespace RMT_API.Data
{
	public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
	{
		public DbSet<AccessTypeMaster> AccessTypeMaster { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Role> Roles { get; set; }  
		public DbSet<Department> Departments { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ResourceDeployment> ResourceDeployments { get; set; }
		public DbSet<Timesheet> Timesheets { get; set; }
		public DbSet<Leave> Leaves { get; set; }
		public DbSet<ResourceOnboarding> ResourceOnboardings { get; set; }
		public DbSet<ResourceOffboarding> ResourceOffboardings { get; set; }
		public DbSet<Users> Users { get; set; }
		public DbSet<Supplier> Supplier { get; set; }
		public DbSet<PublicHoliday> PublicHolidays { get; set; }
	}
}
