using AutoMapper;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;

namespace RMT_API.Infrastructure
{
	public class Automapper : Profile
	{
		public Automapper()
		{
			CreateMap<AccessTypeMasterDto, AccessTypeMaster>().ReverseMap();
			CreateMap<ClientDto, Client>().ReverseMap();
			CreateMap<BaseDto, DepartmentMaster>().ReverseMap();
			CreateMap<LeaveDto, Leave>().ReverseMap();
			CreateMap<ProjectDto, Project>().ReverseMap();
			CreateMap<ResourceDeploymentDto, ResourceDeployment>().ReverseMap();
			CreateMap<ResourceDto, Resource>().ReverseMap();
			CreateMap<ResourceLifeCycleDto, ResourceLifecycle>().ReverseMap();
			CreateMap<ResourceOffboardingDto, ResourceOffboarding>().ReverseMap();
			CreateMap<ResourceOnboardingDto, ResourceOnboarding>().ReverseMap();
			CreateMap<TimesheetDto, Timesheet>().ReverseMap();

			CreateMap<UsersDto, Users>().ReverseMap();
			CreateMap<UserDto, Users>().ReverseMap();
			CreateMap<AccessTypeMaster, UsersDto>().ReverseMap();
			CreateMap<AccessTypeMaster, UserDto>().ReverseMap();

			CreateMap<UsersDto, Users>()
				.ForMember(dest => dest.AccessTypeID, opt => opt.MapFrom(src => src.RoleID));

			CreateMap<Users, UsersDto>()
				.ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.AccessTypeID))
				.ForPath(dest => dest.Role, opt => opt.MapFrom(src => src.AccessType!.Name));

			CreateMap<UserDto, Users>()
				 .ForMember(dest => dest.AccessTypeID, opt => opt.MapFrom(src => src.RoleID));

			CreateMap<Users, UserDto>()
				 .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.AccessTypeID))
				.ForPath(dest => dest.Role, opt => opt.MapFrom(src => src.AccessType!.Name));

			CreateMap<PublicHolidayDto, PublicHolidayMaster>().ReverseMap();
			CreateMap<SupplierDto, Supplier>().ReverseMap();
			CreateMap<ResourceInformation, ResourceInformationDto>().ReverseMap();
		}
	}
}
