using RMT_API.Models;
using RMT_API.Models.MappingModels;
using RMT_API.Repositories;
using RMT_API.Services;

namespace RMT_API.Infrastructure
{
	public static class DependencyInjections
	{
		public static void AddServices(this IServiceCollection services)
		{
			// Register Repositories
			services.AddScoped<IGenericRepository<AccessTypeMaster>, GenericRepository<AccessTypeMaster>>();
			services.AddScoped<IGenericRepository<StateMaster>, GenericRepository<StateMaster>>();
			services.AddScoped<IGenericRepository<PincodeMaster>, GenericRepository<PincodeMaster>>();
			services.AddScoped<IGenericRepository<RegionMater>, GenericRepository<RegionMater>>();
			services.AddScoped<IGenericRepository<SPOC>, GenericRepository<SPOC>>();
			services.AddScoped<IGenericRepository<LocationMaster>, GenericRepository<LocationMaster>>();
			services.AddScoped<IGenericRepository<DomainMaster>, GenericRepository<DomainMaster>>();
			services.AddScoped<IGenericRepository<DomainRoleMaster>, GenericRepository<DomainRoleMaster>>();
			services.AddScoped<IGenericRepository<DomainLevelMaster>, GenericRepository<DomainLevelMaster>>();
			services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();
			services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
			services.AddScoped<IGenericRepository<DepartmentMaster>, GenericRepository<DepartmentMaster>>();
			services.AddScoped<IGenericRepository<Leave>, GenericRepository<Leave>>();
			services.AddScoped<IGenericRepository<Resource>, GenericRepository<Resource>>();
			services.AddScoped<IGenericRepository<ResourceDeployment>, GenericRepository<ResourceDeployment>>();
			services.AddScoped<IGenericRepository<ResourceLifecycle>, GenericRepository<ResourceLifecycle>>();
			services.AddScoped<IGenericRepository<ResourceOffboarding>, GenericRepository<ResourceOffboarding>>();
			services.AddScoped<IGenericRepository<ResourceOnboarding>, GenericRepository<ResourceOnboarding>>();
			services.AddScoped<IGenericRepository<Timesheet>, GenericRepository<Timesheet>>();
			services.AddScoped<IGenericRepository<Users>, GenericRepository<Users>>();
			services.AddScoped<IGenericRepository<Supplier>, GenericRepository<Supplier>>();
			services.AddScoped<IGenericRepository<PublicHolidayMaster>, GenericRepository<PublicHolidayMaster>>();
			services.AddScoped<IGenericRepository<ResourceInformation>, GenericRepository<ResourceInformation>>();
			services.AddScoped<IGenericRepository<AcademicDetails>, GenericRepository<AcademicDetails>>();
			services.AddScoped<IGenericRepository<CertificationDetails>, GenericRepository<CertificationDetails>>();
			services.AddScoped<IGenericRepository<BGVDocuments>, GenericRepository<BGVDocuments>>();
			services.AddScoped<IGenericRepository<Manager>, GenericRepository<Manager>>();
			services.AddScoped<IGenericRepository<ProjectBaseLine>, GenericRepository<ProjectBaseLine>>();
			services.AddScoped<IGenericRepository<DomainRoleMapping>, GenericRepository<DomainRoleMapping>>();

			services.AddScoped<IManagerRepository, ManagerRepository>();
			services.AddScoped<IResourceRepository, ResourceRepository>();
			services.AddScoped<IResourceDeploymentRepository, ResourceDeploymentRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ITimesheetRepository, TimesheetRepository>();
			services.AddScoped<IDashboardDetailsRepository, DashboardDetailsRepository>();
			services.AddScoped<IRepositoryFactory, RepositoryFactory>();
			services.AddScoped<IDomainRoleRepository, DomainRoleRepository>();
			services.AddScoped<IReportsRepository, ReportsRepository>();
			services.AddScoped<ILeavesRepository, LeavesRepository>();

			// Register Services
			services.AddScoped<IAccessTypeService, AccessTypeService>();
			services.AddScoped<IProjectsService, ProjectsService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IClientService, ClientService>();
			services.AddScoped<IDepartmentsService, DepartmentsService>();
			services.AddScoped<ILeaveService, LeaveService>();
			services.AddScoped<IResourcesService, ResourcesService>();
			services.AddScoped<IResourceDeploymentsService, ResourceDeploymentsService>();
			services.AddScoped<IResourceLifecyclesService, ResourceLifecyclesService>();
			services.AddScoped<IResourceOffboardingsService, ResourceOffboardingsService>();
			services.AddScoped<IResourceOnboardingsService, ResourceOnboardingsService>();
			services.AddScoped<ITimesheetsService, TimesheetsService>();
			services.AddScoped<IUsersService, UsersService>();
			services.AddScoped<ISelectValuesService, SelectValuesService>();
			services.AddScoped<ISupplierService, SupplierService>();
			services.AddScoped<IPublicHolidaysService, PublicHolidaysService>();
			services.AddScoped<IResourceInformationService, ResourceInformationService>();
			services.AddScoped<IRegionService, RegionService>();
			services.AddScoped<IDashboardDetailsService, DashboardDetailsService>();
			services.AddScoped<IManagerService, ManagerService>();
			services.AddScoped<IMasterService, MasterService>();
			services.AddScoped<IProjectBaseLineService, ProjectBaseLineService>();
			services.AddScoped<IDomainRoleMappingService, DomainRoleMappingService>();
			services.AddScoped<IReportsService, ReportsService>();
			services.AddScoped<ILeaveService, LeaveService>();

			// Add more repositories and services as needed...
		}
	}
}
