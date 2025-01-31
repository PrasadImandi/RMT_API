using AutoMapper;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;
using RMT_API.Models.BaseModels;

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

			CreateMap<DeliveryMotionMaster, BaseDto>().ReverseMap();
			CreateMap<SegmentMaster, BaseDto>().ReverseMap();
			CreateMap<SupportTypeMaster, BaseDto>().ReverseMap();

			//CreateMap<Project, ProjectDto>().ReverseMap();
			//CreateMap<Client, ProjectDto>().ReverseMap();
			//CreateMap<Manager, ProjectDto>().ReverseMap();
			//CreateMap<ReportingManager, ProjectDto>().ReverseMap();
			//CreateMap<DeliveryMotionMaster, ProjectDto>().ReverseMap();
			//CreateMap<SegmentMaster, ProjectDto>().ReverseMap();
			//CreateMap<SupportTypeMaster, ProjectDto>().ReverseMap();

			//CreateMap<Project, ProjectDto>()
			//		.ForPath(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client!.Name))
			//		.ForPath(dest => dest.PMName, opt => opt.MapFrom(src => src.PM!.FirstName+" "+src.PM!.LastName))
			//		.ForPath(dest => dest.RMName, opt => opt.MapFrom(src => src.RM!.Name))
			//		.ForPath(dest => dest.DeleiveryMotion, opt => opt.MapFrom(src => src.DeleiveryMotion!.Name))
			//		.ForPath(dest => dest.SupportType, opt => opt.MapFrom(src => src.SupportType!.Name))
			//		.ForPath(dest => dest.Segment, opt => opt.MapFrom(src => src.Segment!.Name));

			// Project to ProjectDto Mapping
			CreateMap<Project, ProjectDto>()
				.ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : string.Empty))
				.ForMember(dest => dest.PMName, opt => opt.MapFrom(src => src.PM != null ? (src.PM.FirstName + " " + src.PM.LastName) : string.Empty))
				.ForMember(dest => dest.RMName, opt => opt.MapFrom(src => src.RM != null ? src.RM.Name : string.Empty))
				.ForMember(dest => dest.DeleiveryMotion, opt => opt.MapFrom(src => src.DeleiveryMotion != null ? src.DeleiveryMotion.Name : string.Empty))
				.ForMember(dest => dest.SupportType, opt => opt.MapFrom(src => src.SupportType != null ? src.SupportType.Name : string.Empty))
				.ForMember(dest => dest.Segment, opt => opt.MapFrom(src => src.Segment != null ? src.Segment.Name : string.Empty))
				.ReverseMap();


			CreateMap<ResourceDeploymentDto, ResourceDeployment>().ReverseMap();
			CreateMap<ResourceDto, Resource>().ReverseMap();
			CreateMap<ResourceLifeCycleDto, ResourceLifecycle>().ReverseMap();
			CreateMap<ResourceOffboardingDto, ResourceOffboarding>().ReverseMap();
			CreateMap<ResourceOnboardingDto, ResourceOnboarding>().ReverseMap();
			CreateMap<TimesheetDto, Timesheet>().ReverseMap();

			CreateMap<ResourceIdentifierDto, UsersDto>().ReverseMap();
			CreateMap<ResourceIdentifierDto, UserDto>().ReverseMap();
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
