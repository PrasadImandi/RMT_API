using RMT_API.Models;
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
			services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();
			services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
			services.AddScoped<IGenericRepository<Department>, GenericRepository<Department>>();
			services.AddScoped<IGenericRepository<Leave>, GenericRepository<Leave>>();
			services.AddScoped<IGenericRepository<Resource>, GenericRepository<Resource>>();
			services.AddScoped<IGenericRepository<ResourceDeployment>, GenericRepository<ResourceDeployment>>();
			services.AddScoped<IGenericRepository<ResourceLifecycle>, GenericRepository<ResourceLifecycle>>();
			services.AddScoped<IGenericRepository<ResourceOffboarding>, GenericRepository<ResourceOffboarding>>();
			services.AddScoped<IGenericRepository<ResourceOnboarding>, GenericRepository<ResourceOnboarding>>();
			services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
			services.AddScoped<IGenericRepository<Timesheet>, GenericRepository<Timesheet>>();
			services.AddScoped<IGenericRepository<Users>, GenericRepository<Users>>();
			services.AddScoped<IGenericRepository<Supplier>, GenericRepository<Supplier>>();
			services.AddScoped<IGenericRepository<PublicHoliday>, GenericRepository<PublicHoliday>>();

			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<ILeaveRepository, LeaveRepository>();
			services.AddScoped<IResourceRepository, ResourceRepository>();
			services.AddScoped<IResourceDeploymentRepository, ResourceDeploymentRepository>();
			services.AddScoped<IResourceLifeCycleRepository, ResourceLifeCycleRepository>();
			services.AddScoped<IResourceOffboardingRepository, ResourceOffboardingRepository>();
			services.AddScoped<IResourceOnboardingRepository, ResourceOnboardingRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<ITimesheetRepository, TimesheetRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();



			// Register Services
			services.AddScoped<IAccessTypeService, AccessTypeService>();
			services.AddScoped<IProjectsService, ProjectsService>();
			services.AddScoped<IClientService, ClientService>();
			services.AddScoped<IDepartmentsService, DepartmentsService>();
			services.AddScoped<ILeaveService, LeaveService>();
			services.AddScoped<IResourcesService, ResourcesService>();
			services.AddScoped<IResourceDeploymentsService, ResourceDeploymentsService>();
			services.AddScoped<IResourceLifecyclesService, ResourceLifecyclesService>();
			services.AddScoped<IResourceOffboardingsService, ResourceOffboardingsService>();
			services.AddScoped<IResourceOnboardingsService, ResourceOnboardingsService>();
			services.AddScoped<IRolesService, RolesService>();
			services.AddScoped<ITimesheetsService, TimesheetsService>();
			services.AddScoped<IUsersService, UsersService>();
			services.AddScoped<ISupplierService, SupplierService>();
			services.AddScoped<IPublicHolidaysService, PublicHolidaysService>();

			// Add more repositories and services as needed...
		}
	}
}
