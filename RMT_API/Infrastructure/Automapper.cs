using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using System.Net;

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

			CreateMap<Users, UsersDto>();
			CreateMap<AccessTypeMaster,UsersDto>();



			CreateMap<UsersDto, Users>().ReverseMap()
				 .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.AccessTypeID))
				 .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AccessType!.Name));


			CreateMap<PublicHolidayDto, PublicHoliday>().ReverseMap();
			CreateMap<SupplierDto, Supplier>().ReverseMap();
			CreateMap<ResourceInformation, ResourceInformationDto>().ReverseMap();
		}
	}
}
