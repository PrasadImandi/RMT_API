using Microsoft.EntityFrameworkCore;
using RMT_API.Models;


namespace RMT_API.Data
{
	public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
	{
		public DbSet<AccessTypeMaster> AccessTypeMaster { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ContactInformation> ContactInformation { get; set; }
		public DbSet<ContactType> ContactType { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Domain> Domain { get; set; }
		public DbSet<DomainRole> DomainRoles { get; set; }
		public DbSet<DomainLevel> DomainLevels { get; set; }
		public DbSet<Form> Form { get; set; }
		public DbSet<FormAccess> FormAccess { get; set; }
		public DbSet<Leave> Leaves { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<Manager> Manager { get; set; }
		public DbSet<Pincode> Pincode { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<PublicHoliday> PublicHolidays { get; set; }
		public DbSet<Region> Region { get; set; }
		public DbSet<ReportingManager> ReportingManager { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<ResourceDeployment> ResourceDeployments { get; set; }
		public DbSet<ResourceInformation> ResourceInformation { get; set; }
		public DbSet<ResourceOnboarding> ResourceOnboardings { get; set; }
		public DbSet<ResourceOffboarding> ResourceOffboardings { get; set; }
		public DbSet<ResourceLifecycle> ResourceLifecycles { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<SPOC> SPOC { get; set; }
		public DbSet<State> State { get; set; }
		public DbSet<Supplier> Supplier { get; set; }
		public DbSet<Timesheet> Timesheets { get; set; }
		public DbSet<Users> Users { get; set; }

		public DbSet<PersonalDetails> PersonalDetails { get; set; }
		public DbSet<ProfessionalDetails> ProfessionalDetails { get; set; }
		public DbSet<Documents> Documents { get; set; }
		public DbSet<AcademicDetails> AcademicDetails { get; set; }
		public DbSet<CertificationDetails> CertificationDetails { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Resource>()
				.HasOne(r => r.ResourceInformation)
				.WithOne()
				.HasForeignKey<ResourceInformation>(p => p.ID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ResourceInformation>()
				.HasOne(r => r.Personal)
				.WithOne()
				.HasForeignKey<PersonalDetails>(p => p.ResourceInformationId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ResourceInformation>()
				.HasOne(r => r.Professional)
				.WithOne()
				.HasForeignKey<ProfessionalDetails>(p => p.ResourceInformationId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ResourceInformation>()
				.HasOne(r => r.Documents)
				.WithOne()
				.HasForeignKey<Documents>(d => d.ResourceInformationId)
				.OnDelete(DeleteBehavior.Restrict);
			
			modelBuilder.Entity<ResourceInformation>()
				.HasMany(r => r.Academic)
				.WithOne()
				.HasForeignKey(a => a.ResourceInformationId);

			modelBuilder.Entity<ResourceInformation>()
				.HasMany(r => r.Certification)
				.WithOne()
				.HasForeignKey(c => c.ResourceInformationId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
