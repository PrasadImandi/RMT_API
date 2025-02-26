using AutoMapper;
using RMT_API.DTOs;
using RMT_API.DTOs.BaseDtos;
using RMT_API.DTOs.ReportsDtos;
using RMT_API.Models;
using RMT_API.Models.MappingModels;

namespace RMT_API.Infrastructure
{
	public class Automapper : Profile
	{
		public Automapper()
		{
			CreateMap<AccessTypeMasterDto, AccessTypeMaster>().ReverseMap();
			CreateMap<ClientDto, Client>().ReverseMap();

			CreateMap<BaseDto, Client>().ReverseMap();
			CreateMap<BaseDto, ContactTypeMaster>().ReverseMap();
			CreateMap<BaseDto, StateMaster>().ReverseMap();
			CreateMap<BaseDto, DeliveryMotionMaster>().ReverseMap();
			CreateMap<BaseDto, PincodeMaster>().ReverseMap();
			CreateMap<BaseDto, RegionMater>().ReverseMap();
			CreateMap<BaseDto, LocationMaster>().ReverseMap();
			CreateMap<BaseDto, SPOC>().ReverseMap();
			CreateMap<BaseDto, DomainMaster>().ReverseMap();
			CreateMap<BaseDto, DomainRoleMaster>().ReverseMap();
			CreateMap<BaseDto, DomainLevelMaster>().ReverseMap();

			CreateMap<BaseDto, DepartmentMaster>().ReverseMap();
			CreateMap<LeaveDto, Leave>().ReverseMap();
			CreateMap<ProjectDto, Project>();

			CreateMap<DeliveryMotionMaster, BaseDto>().ReverseMap();
			CreateMap<SegmentMaster, BaseDto>().ReverseMap();
			CreateMap<SupportTypeMaster, BaseDto>().ReverseMap();

			// Project to ProjectDto Mapping
			CreateMap<Project, ProjectDto>()
				.ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : string.Empty))
				.ForMember(dest => dest.PMName, opt => opt.MapFrom(src => src.PM != null ? (src.PM.FirstName + " " + src.PM.LastName) : string.Empty))
				.ForMember(dest => dest.RMName, opt => opt.MapFrom(src => src.RM != null ? src.RM.Name : string.Empty))
				.ForMember(dest => dest.DeleiveryMotionName, opt => opt.MapFrom(src => src.DeleiveryMotion != null ? src.DeleiveryMotion.Name : string.Empty))
				.ForMember(dest => dest.SupportTypeName, opt => opt.MapFrom(src => src.SupportType != null ? src.SupportType.Name : string.Empty))
				.ForMember(dest => dest.SegmentName, opt => opt.MapFrom(src => src.Segment != null ? src.Segment.Name : string.Empty));

			CreateMap<ProjectDto, Project>();

			CreateMap<ResourceDeploymentDto, ResourceDeployment>().ReverseMap();
			CreateMap<ResourceDto, Resource>().ReverseMap();
			CreateMap<ResourceLifeCycleDto, ResourceLifecycle>().ReverseMap();
			CreateMap<ResourceOffboardingDto, ResourceOffboarding>().ReverseMap();
			CreateMap<ResourceOnboardingDto, ResourceOnboarding>().ReverseMap();
			CreateMap<TimesheetDto, Timesheet>();
			CreateMap<ProjectTimesheetDetail, ProjectTimesheetDetailDto>()
				.ForMember(dest => dest.TimesheetDetails, opt => opt.MapFrom(src => src.TimesheetDetails));
			CreateMap<ProjectTimesheetDetailDto, ProjectTimesheetDetail>();
			CreateMap<TimesheetDetail, TimesheetDetailDto>().ReverseMap();
			CreateMap<Timesheet, TimesheetDto>()
				.ForMember(dest => dest.ProjectTimesheetDetails, opt => opt.MapFrom(src => src.ProjectTimesheetDetails));

			CreateMap<ResourceIdentifierDto, UsersDto>().ReverseMap();
			CreateMap<ResourceIdentifierDto, UserDto>().ReverseMap();
			CreateMap<UsersDto, Users>().ReverseMap();
			CreateMap<UserDto, Users>().ReverseMap();
			CreateMap<AccessTypeMaster, UsersDto>().ReverseMap();
			CreateMap<AccessTypeMaster, UserDto>().ReverseMap();
			CreateMap<CertificationDetailsDto, CertificationDetails>().ReverseMap();

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
			CreateMap<SupplierDto, Supplier>();
			CreateMap<ContactInformationDto, ContactInformation>().ReverseMap();
			CreateMap<ManagerDto, Manager>().ReverseMap();

			CreateMap<Supplier, SupplierDto>()
				.ForMember(dest => dest.ContactInformation, opt => opt.MapFrom(src => src.ContactInformation));

			CreateMap<ResourceInformation, ResourceInformationDto>();
			CreateMap<CertificationDetails, ResourceInformationDto>();
			CreateMap<PersonalDetails, ResourceInformationDto>();
			CreateMap<ProfessionalDetails, ResourceInformationDto>();
			CreateMap<AcademicDetails, ResourceInformationDto>();
			CreateMap<Documents, ResourceInformationDto>();


			CreateMap<ResourceInformationDto, ResourceInformation>();
			CreateMap <CertificationDetailsDto, ResourceInformation>();

			CreateMap<ResourceInformationDto, ResourceInformation>()
				.ForMember(dest => dest.AcademicDetails, opt => opt.MapFrom(src => src.Academic))
				.ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents))
				.ForMember(dest => dest.Professional, opt => opt.MapFrom(src => src.Professional))
				.ForMember(dest => dest.Personal, opt => opt.MapFrom(src => src.Personal))
				.ForMember(dest => dest.Certifications, opt => opt.MapFrom(src => src.Certification));


			CreateMap<DomainRoleMappingDto, DomainRoleMapping>().ReverseMap();
			CreateMap<ProjectBaseLineDto, ProjectBaseLine>().ReverseMap();
			CreateMap<ClientReportsDto, ClientReports>().ReverseMap();

		}
	}
}
