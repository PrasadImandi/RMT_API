using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Infrastructure
{
	public class Automapper :Profile
	{
		public Automapper()
		{
			CreateMap<AccessTypeMasterDto, AccessTypeMaster>().ReverseMap();
			CreateMap<ClientDto, Client>().ReverseMap();
			CreateMap<DepartmentDto, Department>().ReverseMap();
			CreateMap<LeaveDto, Leave>().ReverseMap();
			CreateMap<ProjectDto, Project>().ReverseMap();
			CreateMap<ResourceDeploymentDto, ResourceDeployment>().ReverseMap();
			CreateMap<ResourceDto, Resource>().ReverseMap();
			CreateMap<ResourceLifeCycleDto, ResourceLifecycle>().ReverseMap();
			CreateMap<ResourceOffboardingDto, ResourceOffboarding>().ReverseMap();
			CreateMap<ResourceOnboardingDto, ResourceOnboarding>().ReverseMap();
			CreateMap<RoleDto, Role>().ReverseMap();
			CreateMap<TimesheetDto, Timesheet>().ReverseMap();
			CreateMap<UsersDto, Users>().ReverseMap();
			CreateMap<PublicHolidayDto, PublicHoliday>().ReverseMap();
			CreateMap<SupplierDto, Supplier>().ReverseMap();
		}
	}
}
