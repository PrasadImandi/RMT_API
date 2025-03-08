using Microsoft.EntityFrameworkCore;
using RMT_API.Models;
using RMT_API.Models.BaseModels;
using RMT_API.Models.MappingModels;


namespace RMT_API.Data
{
	public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
	{
		#region Master Tables
		public DbSet<AccessTypeMaster> AccessTypeMaster { get; set; }
		public DbSet<SegmentMaster> SegmentMaster { get; set; }
		public DbSet<DeliveryMotionMaster> DeliveryMotionMaster { get; set; }
		public DbSet<SupportTypeMaster> SupportTypeMaster { get; set; }
		public DbSet<DomainMaster> DomainMaster { get; set; }
		public DbSet<DomainRoleMaster> DomainRoleMaster { get; set; }
		public DbSet<DomainLevelMaster> DomainLevelMaster { get; set; }
		public DbSet<LocationMaster> LocationMaster { get; set; }
		public DbSet<PincodeMaster> PincodeMaster { get; set; }
		public DbSet<RegionMater> RegionMaster { get; set; }
		public DbSet<StateMaster> StateMaster { get; set; }
		public DbSet<FormMaster> FormMaster { get; set; }
		public DbSet<ContactTypeMaster> ContactTypeMaster { get; set; }
		public DbSet<PublicHolidayMaster> PublicHolidaysMaster { get; set; }
		public DbSet<ManagerTypeMaster> ManagerTypeMaster { get; set; }

		#endregion Master Tables

		#region Tables
		public DbSet<Client> Clients { get; set; }
		public DbSet<ContactInformation> ContactInformation { get; set; }
		public DbSet<DepartmentMaster> Departments { get; set; }
		public DbSet<FormAccess> FormAccess { get; set; }
		public DbSet<Leave> Leaves { get; set; }
		public DbSet<Manager> Manager { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ReportingManager> ReportingManager { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<ResourceDeployment> ResourceDeployments { get; set; }
		public DbSet<ResourceInformation> ResourceInformation { get; set; }
		public DbSet<ResourceOnboarding> ResourceOnboardings { get; set; }
		public DbSet<ResourceOffboarding> ResourceOffboardings { get; set; }
		public DbSet<ResourceLifecycle> ResourceLifecycles { get; set; }
		public DbSet<SPOC> SPOC { get; set; }
		public DbSet<Supplier> Supplier { get; set; }
		public DbSet<Timesheet> Timesheet { get; set; }
		public DbSet<ProjectTimesheetDetail> ProjectTimesheetDetail { get; set; }
		public DbSet<TimesheetDetail> TimesheetDetail { get; set; }
		public DbSet<Users> Users { get; set; }

		public DbSet<PersonalDetails> PersonalDetails { get; set; }
		public DbSet<ProfessionalDetails> ProfessionalDetails { get; set; }
		public DbSet<Documents> Documents { get; set; }
		public DbSet<AcademicDetails> AcademicDetails { get; set; }
		public DbSet<CertificationDetails> CertificationDetails { get; set; }
		public DbSet<DomainRoleMapping> DomainRoleMappings { get; set; }
		public DbSet<ProjectBaseLine> ProjectBaseLine { get; set; }

		#endregion Tables

		#region Reports

		public DbSet<ClientReports> ClientReports { get; set; }
		public DbSet<SupplierReports> SupplierReports { get; set; }
		public DbSet<ResourceReports> ResourceReports { get; set; }
		public DbSet<ProjectReports> ProjectReports { get; set; }

		#endregion Reports

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Models

			#region AcademicDetails
			modelBuilder.Entity<AcademicDetails>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<AcademicDetails>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<AcademicDetails>()
			.HasIndex(a => a.Name)
			.IsUnique();

			modelBuilder.Entity<AcademicDetails>()
				.Property(a => a.CompletionDate)
				.IsRequired();

			modelBuilder.Entity<AcademicDetails>()
				.Property(a => a.ResultPercentage)
				.IsRequired();

			modelBuilder.Entity<AcademicDetails>()
				.Property(a => a.Attachment)
				.IsRequired(false);

			#endregion AcademicDetails

			#region AccessTypeMaster

			modelBuilder.Entity<AccessTypeMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<AccessTypeMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<AccessTypeMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion AccessTypeMaster

			#region BGV Documents

			modelBuilder.Entity<BGVDocuments>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<BGVDocuments>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<BGVDocuments>()
			.Property(a => a.Description)
			.HasColumnType("varchar(500)")
			.IsRequired(false);

			modelBuilder.Entity<BGVDocuments>()
			.Property(a => a.Attachments)
			.HasColumnType("nvarchar(max)")
			.IsRequired(false);

			#endregion BGV Documents

			#region CertificationDetails

			modelBuilder.Entity<CertificationDetails>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<CertificationDetails>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<CertificationDetails>()
				.Property(a => a.CertificationNumber)
				.IsRequired();

			modelBuilder.Entity<CertificationDetails>()
				.Property(a => a.CompletionDate)
				.IsRequired();

			modelBuilder.Entity<CertificationDetails>()
				.Property(a => a.ExpiryDate)
				.IsRequired();

			modelBuilder.Entity<CertificationDetails>()
				.Property(a => a.Attachment)
				.IsRequired(false);

			#endregion Certification Details

			#region Clients

			modelBuilder.Entity<Client>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<Client>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Client>()
			.HasIndex(a => a.Name)
			.IsUnique();

			modelBuilder.Entity<Client>()
			.Property(a => a.ClientCode)
			.HasComputedColumnSql("CONCAT('C', RIGHT('10000' + CAST(ID AS VARCHAR), 5))", stored: true)
			.IsRequired();

			modelBuilder.Entity<Client>()
				.Property(a => a.ShortName)
				.HasColumnType("varchar(50)")
				.IsRequired();

			modelBuilder.Entity<Client>()
				.Property(a => a.StartDate)
				.IsRequired();

			modelBuilder.Entity<Client>()
				.Property(a => a.EndDate)
				.IsRequired();

			modelBuilder.Entity<Client>()
				.Property(a => a.Address)
				.HasColumnType("varchar(200)")
				.IsRequired(false);

			modelBuilder.Entity<Client>()
				.Property(a => a.Notes)
				.HasColumnType("varchar(500)")
				.IsRequired(false);


			#endregion Clients

			#region ContactInformation

			modelBuilder.Entity<ContactInformation>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<ContactInformation>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<ContactInformation>()
			.HasIndex(a => a.Name)
			.IsUnique();


			modelBuilder.Entity<ContactInformation>()
				.Property(a => a.ContactTypeID)
				.IsRequired();

			modelBuilder.Entity<ContactInformation>()
				.Property(a => a.ContactNumber)
				.HasColumnType("varchar(20)")
				.IsRequired();

			modelBuilder.Entity<ContactInformation>()
				.Property(a => a.ContactEmail)
				.HasColumnType("varchar(60)")
				.IsRequired(false);

			modelBuilder.Entity<ContactInformation>()
				.HasOne(c => c.ContactType)
				.WithMany(p => p.ContactInformations)
				.HasForeignKey(c => c.ContactTypeID)
				.OnDelete(DeleteBehavior.SetNull);

			#endregion ContactInformation

			#region ContactTypeMaster

			modelBuilder.Entity<ContactTypeMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<ContactTypeMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<ContactTypeMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion ContactTypeMaster

			#region DeliveryMotionMaster

			modelBuilder.Entity<DeliveryMotionMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<DeliveryMotionMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<DeliveryMotionMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion DeliveryMotionMaster

			#region DepartmentMaster

			modelBuilder.Entity<DepartmentMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<DepartmentMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<DepartmentMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion DepartmentMaster

			#region Documents

			modelBuilder.Entity<Documents>()
				.HasKey(a => a.ID);

			#endregion Documents

			#region DomainMaster

			modelBuilder.Entity<DomainMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<DomainMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<DomainMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion DomainMaster

			#region DomainLevelMaster

			modelBuilder.Entity<DomainLevelMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<DomainLevelMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<DomainLevelMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion DomainLevelMaster

			#region DomainRoleMaster

			modelBuilder.Entity<DomainRoleMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<DomainRoleMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<DomainRoleMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();
			#endregion

			#region FormMaster

			modelBuilder.Entity<FormMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<FormMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<FormMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion FormMaster

			#region FormAccess

			modelBuilder.Entity<FormAccess>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<FormAccess>()
			.Property(a => a.AccessTypeID)
			.IsRequired();

			modelBuilder.Entity<FormAccess>()
			.Property(a => a.FormID)
			.IsRequired();

			#endregion FormMaster

			#region JoiningDocuments

			modelBuilder.Entity<JoiningDocuments>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.AadharCard)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.AppraisalLetter)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.DrivingLicense)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.OfferLetter)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.JoiningLetter)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.PanCard)
			.HasColumnType("varchar(30)")
			.IsRequired();

			modelBuilder.Entity<JoiningDocuments>()
			.Property(a => a.Passport)
			.HasColumnType("varchar(30)")
			.IsRequired();

			#endregion FormMaster

			#region LaptopProviderMaster

			modelBuilder.Entity<LaptopProviderMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<LaptopProviderMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<LaptopProviderMaster>()
		.HasIndex(a => a.Name)
		.IsUnique();

			#endregion LaptopProviderMaster

			#region Leave

			modelBuilder.Entity<Leave>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<Leave>()
			.Property(a => a.ResourceID)
			.IsRequired();

			modelBuilder.Entity<Leave>()
			.Property(a => a.LeaveTypeID)
			.IsRequired();

			modelBuilder.Entity<Leave>()
			.Property(a => a.StartDate)
			.IsRequired();

			modelBuilder.Entity<Leave>()
			.Property(a => a.EndDate)
			.IsRequired();

			modelBuilder.Entity<Leave>()
			.Property(a => a.Status)
			.HasColumnType("varchar(15)")
			.IsRequired();

			modelBuilder.Entity<Leave>()
			.Property(a => a.ApproverID)
			.IsRequired();

			#endregion Leave

			#region LeaveTypeMaster

			modelBuilder.Entity<LeaveTypeMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<LeaveTypeMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<LeaveTypeMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion LeaveTypeMaster

			#region LocationMaster

			modelBuilder.Entity<LocationMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<LocationMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();


			modelBuilder.Entity<LocationMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			modelBuilder.Entity<LocationMaster>()
			.Property(a => a.Code)
			.HasColumnType("varchar(20)")
			.IsRequired();

			#endregion LocationMaster

			#region Manager

			modelBuilder.Entity<Manager>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<Manager>()
			.Property(a => a.FirstName)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Manager>()
			.Property(a => a.LastName)
			.HasColumnType("varchar(100)")
			.IsRequired(false);

			modelBuilder.Entity<Manager>()
			.Property(a => a.ContactNumber)
			.HasColumnType("varchar(20)")
			.IsRequired();

			modelBuilder.Entity<Manager>()
			.Property(a => a.LastName)
			.HasColumnType("varchar(60)")
			.IsRequired();

			modelBuilder.Entity<Manager>()
			.Property(a => a.ManagerTypeID)
			.IsRequired();

			modelBuilder.Entity<Manager>()
			.Property(a => a.ParentManagerId);

			#endregion Manager

			#region PersonalDetails

			modelBuilder.Entity<PersonalDetails>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.FathersName)
			.HasColumnType("varchar(100)")
			.IsRequired(false);

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.MothersName)
			.HasColumnType("varchar(100)")
			.IsRequired(false);

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.DateOfBirth)
			.IsRequired();

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.AlternateContactNumber)
			.HasColumnType("varchar(20)")
			.IsRequired();

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.EmergencyContactNumber)
			.HasColumnType("varchar(20)")
			.IsRequired();

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.HometownAddress)
			.HasColumnType("varchar(20)");

			modelBuilder.Entity<PersonalDetails>()
			.Property(a => a.OfficialMailingAddress)
			.HasColumnType("varchar(60)");

			#endregion Manager

			#region PincodeMaster

			modelBuilder.Entity<PincodeMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<PincodeMaster>()
			.Property(a => a.Code)
			.HasColumnType("varchar(20)")
			.IsRequired();

			modelBuilder.Entity<PincodeMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			#endregion PincodeMaster

			#region ProfessionalDetails

			modelBuilder.Entity<ProfessionalDetails>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.AssetAssignedDate);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.AssetModelNo)
			.HasColumnType("varchar(50)");

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.AssetSerialNo)
			.HasColumnType("varchar(50)");

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.AttendanceRequired);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.CWFID)
			.HasColumnType("varchar(50)");

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.OfficialEmailID)
			.HasColumnType("varchar(60)");

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.LastWorkingDate);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.OverallExperience);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.PONo)
			.HasColumnType("varchar(50)");

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.PODate);

			modelBuilder.Entity<ProfessionalDetails>()
			.Property(a => a.JoiningDate);



			#endregion ProfessionalDetails

			#region Project

			modelBuilder.Entity<Project>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<Project>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Project>()
			.Property(a => a.ProjectCode);

			modelBuilder.Entity<Project>()
			.Property(a => a.StartDate)
			.IsRequired();

			modelBuilder.Entity<Project>()
			.Property(a => a.EndDate)
			.IsRequired();

			#endregion Project

			#region PublicHolidayMaster

			modelBuilder.Entity<PublicHolidayMaster>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<PublicHolidayMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<PublicHolidayMaster>()
			.HasIndex(a => a.Name)
			.IsUnique();

			modelBuilder.Entity<PublicHolidayMaster>()
			.Property(a => a.Description)
			.HasColumnType("varchar(200)")
			.IsRequired();

			modelBuilder.Entity<PublicHolidayMaster>()
			.Property(a => a.IsPublic);

			modelBuilder.Entity<PublicHolidayMaster>()
			.Property(a => a.PHDate);

			modelBuilder.Entity<PublicHolidayMaster>()
			.Property(a => a.PHYear);

			#endregion PublicHolidayMaster

			#region RegionMater

			modelBuilder.Entity<RegionMater>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<RegionMater>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<RegionMater>()
			.Property(a => a.Code)
			.HasColumnType("varchar(20)")
			.IsRequired();

			#endregion RegionMater

			#region ReportingManager

			modelBuilder.Entity<ReportingManager>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ReportingManager>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<ReportingManager>()
			.Property(a => a.RMContactNumber)
			.HasColumnType("varchar(20)");

			modelBuilder.Entity<ReportingManager>()
			.Property(a => a.RMEmailID)
			.HasColumnType("varchar(60)");

			#endregion ReportingManager

			#region Resource

			modelBuilder.Entity<Resource>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<Resource>()
			.Property(a => a.FirstName)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Resource>()
			.Property(a => a.LastName)
			.HasColumnType("varchar(100)");

			modelBuilder.Entity<Resource>()
			.Property(a => a.ResourceCode)
			.HasComputedColumnSql("CONCAT('RES', RIGHT('10000' + CAST(ID AS VARCHAR), 5))", stored: true)
			.IsRequired();

			modelBuilder.Entity<Resource>()
			.Property(a => a.EmailID)
			.HasColumnType("varchar(60)");

			modelBuilder.Entity<Resource>()
			.Property(a => a.MobileNumber)
			.HasColumnType("varchar(60)");

			modelBuilder.Entity<Resource>()
			.HasIndex(a => a.ResourceInformationID)
			.IsUnique();



			#endregion PublicHolidayMaster

			#region ResourceDeployment

			modelBuilder.Entity<ResourceDeployment>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ResourceDeployment>()
			.Property(a => a.ResourceID)
			.IsRequired();

			modelBuilder.Entity<ResourceDeployment>()
			.Property(a => a.ProjectID);

			modelBuilder.Entity<ResourceDeployment>()
			.Property(a => a.StartDate);

			modelBuilder.Entity<ResourceDeployment>()
			.Property(a => a.EndDate);

			modelBuilder.Entity<ResourceDeployment>()
			.Property(a => a.AllocationPercent)
			.HasColumnType("decimal(18,2)");

			#endregion

			#region ResourceInformation

			modelBuilder.Entity<ResourceInformation>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ResourceInformation>()
			.Property(a => a.ResourceID)
			.IsRequired();

			#endregion ResourceInformation

			#region ResourceLifecycle

			modelBuilder.Entity<ResourceLifecycle>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ResourceLifecycle>()
			.Property(a => a.ResourceID)
			.IsRequired();

			modelBuilder.Entity<ResourceLifecycle>()
			.Property(a => a.StartDate)
			.IsRequired();

			modelBuilder.Entity<ResourceLifecycle>()
			.Property(a => a.EndDate);

			modelBuilder.Entity<ResourceLifecycle>()
			.Property(a => a.Notes)
			.HasColumnType("varchar(200)");

			#endregion ResourceLifecycle

			#region ResourceOffboarding

			modelBuilder.Entity<ResourceOffboarding>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.OffboardingDate);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.HandledByID);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.ExitDocumentName)
			.HasColumnType("varchar(50)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.ExitDocumentName)
			.HasColumnType("varchar(200)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.FileType)
			.HasColumnType("varchar(20)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.ExitReason)
			.HasColumnType("varchar(500)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOffboarding>()
			.Property(a => a.Notes)
			.HasColumnType("varchar(500)")
			.IsRequired(false);

			#endregion ResourceOffboarding

			#region ResourceOnboarding

			modelBuilder.Entity<ResourceOnboarding>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.ResourceID)
			.IsRequired();

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.HandledByID);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.OnboardingDate);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.DocumentName)
			.HasColumnType("varchar(50)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.DocumentPath)
			.HasColumnType("varchar(200)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.FileType)
			.HasColumnType("varchar(20)")
			.IsRequired(false);

			modelBuilder.Entity<ResourceOnboarding>()
			.Property(a => a.Notes)
			.HasColumnType("varchar(500)")
			.IsRequired(false);

			#endregion ResourceOffboarding

			#region SegmentMaster

			modelBuilder.Entity<SegmentMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<SegmentMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			#endregion SegmentMaster

			#region SPOC

			modelBuilder.Entity<SPOC>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<SPOC>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<SPOC>()
			.Property(a => a.SPOCContactNumber)
			.HasColumnType("varchar(20)");

			modelBuilder.Entity<SPOC>()
			.Property(a => a.SPOCEmailID)
			.HasColumnType("varchar(60)");

			#endregion SPOC

			#region StateMaster

			modelBuilder.Entity<StateMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<StateMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<StateMaster>()
			.Property(a => a.Code)
			.HasColumnType("varchar(100)");

			#endregion StateMaster

			#region Supplier

			modelBuilder.Entity<Supplier>()
			.HasKey(a => a.ID);

			modelBuilder.Entity<Supplier>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Supplier>()
			.Property(a => a.Supplier_Code)
			.HasComputedColumnSql("CONCAT('S', RIGHT('10000' + CAST(ID AS VARCHAR), 5))", stored: true)
			.IsRequired();

			modelBuilder.Entity<Supplier>()
			.Property(a => a.SIDDate)
			.IsRequired(false);

			modelBuilder.Entity<Supplier>()
			.Property(a => a.Address)
			.HasColumnType("varchar(200)")
			.IsRequired(false);

			modelBuilder.Entity<Supplier>()
			.Property(a => a.GST)
			.HasColumnType("varchar(60)")
			.IsRequired(false);

			modelBuilder.Entity<Supplier>()
			.Property(a => a.TAN)
			.HasColumnType("varchar(20)")
			.IsRequired(false);

			modelBuilder.Entity<Supplier>()
			.Property(a => a.PAN)
			.HasColumnType("varchar(20)")
			.IsRequired(false);

			#endregion Supplier

			#region SupportTypeMaster

			modelBuilder.Entity<SupportTypeMaster>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<SupportTypeMaster>()
			.Property(a => a.Name)
			.HasColumnType("varchar(100)")
			.IsRequired();

			#endregion SupportTypeMaster

			#region Timesheet

			modelBuilder.Entity<Timesheet>()
				.HasKey(a => a.ID);

			#endregion Timesheet

			#region Users

			modelBuilder.Entity<Users>()
				.HasKey(a => a.ID);

			modelBuilder.Entity<Users>()
			.Property(a => a.FirstName)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Users>()
			.Property(a => a.LastName)
			.HasColumnType("varchar(100)")
			.IsRequired(false);

			modelBuilder.Entity<Users>()
			.Property(a => a.Email)
			.HasColumnType("varchar(100)")
			.IsRequired(false);

			modelBuilder.Entity<Users>()
			.Property(a => a.UserName)
			.HasColumnType("varchar(100)")
			.IsRequired();

			modelBuilder.Entity<Users>()
			.Property(a => a.Password)
			.HasColumnType("varchar(max)")
			.IsRequired();

			#endregion Users


			modelBuilder.Entity<ClientReports>().HasNoKey();
			modelBuilder.Entity<SupplierReports>().HasNoKey();
			modelBuilder.Entity<ResourceReports>().HasNoKey();
			modelBuilder.Entity<ProjectReports>().HasNoKey();

			#endregion Models

			#region Relationships

			modelBuilder.Entity<Project>()
			.HasOne(p => p.RM)
			.WithMany(rm => rm.Projects)
			.HasForeignKey(p => p.RMID)
			.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Resource>()
			.HasOne(b => b.ResourceInformation)
			.WithOne(d => d.ResourceDetails)
			.HasForeignKey<Resource>(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<PersonalDetails>()
			.HasOne(b => b.ResourceInformation)
			.WithOne(d => d.Personal)
			.HasForeignKey<PersonalDetails>(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ProfessionalDetails>()
			.HasOne(b => b.ResourceInformation)
			.WithOne(d => d.Professional)
			.HasForeignKey<ProfessionalDetails>(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Documents>()
			.HasOne(b => b.ResourceInformation)
			.WithOne(d => d.Documents)
			.HasForeignKey<Documents>(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<AcademicDetails>()
			.HasOne(b => b.ResourceInformation)
			.WithMany(d => d.AcademicDetails)
			.HasForeignKey(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<CertificationDetails>()
			.HasOne(b => b.ResourceInformation)
			.WithMany(d => d.Certifications)
			.HasForeignKey(b => b.ResourceInformationID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<BGVDocuments>()
			.HasOne(b => b.Documents)
			.WithMany(d => d.BGV)
			.HasForeignKey(b => b.DocumentsID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<JoiningDocuments>()
			.HasOne(b => b.Documents)
			.WithOne(d => d.Joining)
			.HasForeignKey<JoiningDocuments>(b => b.DocumentsID)
			.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<DomainRoleMapping>()
		   .HasKey(dm => dm.ID); // Set the primary key

			// Configure the relationship between DomainRoleMapping and DomainRole
			modelBuilder.Entity<DomainRoleMapping>()
				.HasOne(dm => dm.DomainRole) // Each DomainRoleMapping has one DomainRole
				.WithMany() // Each DomainRole can be mapped to many DomainRoleMappings
				.HasForeignKey(dm => dm.RoleID) // Foreign key to DomainRole
				.OnDelete(DeleteBehavior.Restrict); // Avoid cascading deletes


			modelBuilder.Entity<ProjectBaseLine>()
			.HasOne(b => b.Client)
			.WithOne()
			.HasForeignKey<ProjectBaseLine>(b => b.LogoID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ProjectBaseLine>()
			.HasOne(b => b.Project)
			.WithOne()
			.HasForeignKey<ProjectBaseLine>(b => b.ProjectID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ProjectBaseLine>()
			.HasOne(b => b.Domain)
			.WithOne()
			.HasForeignKey<ProjectBaseLine>(b => b.DomainID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ProjectBaseLine>()
			.HasOne(b => b.DomainRole)
			.WithOne()
			.HasForeignKey<ProjectBaseLine>(b => b.RoleID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ProjectBaseLine>()
			.HasOne(b => b.DomainLevel)
			.WithOne()
			.HasForeignKey<ProjectBaseLine>(b => b.LevelID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Client>()
			.HasOne(b => b.RegionMater)
			.WithOne()
			.HasForeignKey<Client>(b => b.RegionID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Client>()
			.HasOne(b => b.StateMaster)
			.WithOne()
			.HasForeignKey<Client>(b => b.StateID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Client>()
			.HasOne(b => b.LocationMaster)
			.WithOne()
			.HasForeignKey<Client>(b => b.LocationID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Client>()
			.HasOne(b => b.PincodeMaster)
			.WithOne()
			.HasForeignKey<Client>(b => b.PincodeID)
			.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Client>()
			.HasOne(b => b.SPOC)
			.WithOne()
			.HasForeignKey<Client>(b => b.SPOCID)
			.OnDelete(DeleteBehavior.SetNull);

			#endregion Relationships

			base.OnModelCreating(modelBuilder);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entries = ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Modified)
				{
					if (entry.Entity is BaseModel auditable)
					{
						auditable.Updated_Date = DateTime.UtcNow;
						auditable.Updated_By = 1;
					}
					else if (entry.Entity is ResourceIdentifier resourceIdentifier)
					{
						resourceIdentifier.Updated_Date = DateTime.UtcNow;
						resourceIdentifier.Updated_By = 1;
					}
				}
				else if (entry.State == EntityState.Added)
				{
					if (entry.Entity is BaseModel auditable)
					{
						auditable.Created_Date = DateTime.UtcNow;
						auditable.Created_By = 1;
					}
					else if (entry.Entity is ResourceIdentifier resourceIdentifier)
					{
						resourceIdentifier.Created_Date = DateTime.UtcNow;
						resourceIdentifier.Created_By = 1;
					}
				}
			}

			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
