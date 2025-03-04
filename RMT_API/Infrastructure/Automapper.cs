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
			CreateMap<BaseDto, FormMaster>().ReverseMap();

			CreateMap<BaseDto, DepartmentMaster>().ReverseMap();
			CreateMap<LeaveDto, Leave>().ReverseMap();
			CreateMap<ProjectDto, Project>();

			CreateMap<DeliveryMotionMaster, BaseDto>().ReverseMap();
			CreateMap<SegmentMaster, BaseDto>().ReverseMap();
			CreateMap<SupportTypeMaster, BaseDto>().ReverseMap();

			// Project to ProjectDto Mapping
			CreateMap<Project, ProjectDto>()
				.ForMember(destination => destination.ClientName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : string.Empty))
				.ForMember(destination => destination.PMName, opt => opt.MapFrom(src => src.PM != null ? (src.PM.FirstName + " " + src.PM.LastName) : string.Empty))
				.ForMember(destination => destination.RMName, opt => opt.MapFrom(src => src.RM != null ? src.RM.Name : string.Empty))
				.ForMember(destination => destination.DeleiveryMotionName, opt => opt.MapFrom(src => src.DeleiveryMotion != null ? src.DeleiveryMotion.Name : string.Empty))
				.ForMember(destination => destination.SupportTypeName, opt => opt.MapFrom(src => src.SupportType != null ? src.SupportType.Name : string.Empty))
				.ForMember(destination => destination.SegmentName, opt => opt.MapFrom(src => src.Segment != null ? src.Segment.Name : string.Empty));

			CreateMap<ProjectDto, Project>();

			CreateMap<ResourceDeploymentDto, ResourceDeployment>().ReverseMap();
			CreateMap<ResourceDto, Resource>().ReverseMap();
			CreateMap<ResourceLifeCycleDto, ResourceLifecycle>().ReverseMap();
			CreateMap<ResourceOffboardingDto, ResourceOffboarding>().ReverseMap();
			CreateMap<ResourceOnboardingDto, ResourceOnboarding>().ReverseMap();
			CreateMap<TimesheetDto, Timesheet>();
			CreateMap<ProjectTimesheetDetail, ProjectTimesheetDetailDto>()
				.ForMember(destination => destination.TimesheetDetails, opt => opt.MapFrom(src => src.TimesheetDetails));
			CreateMap<ProjectTimesheetDetailDto, ProjectTimesheetDetail>();
			CreateMap<TimesheetDetail, TimesheetDetailDto>().ReverseMap();
			CreateMap<Timesheet, TimesheetDto>()
				.ForMember(destination => destination.ProjectTimesheetDetails, opt => opt.MapFrom(src => src.ProjectTimesheetDetails));

			CreateMap<ResourceIdentifierDto, UsersDto>().ReverseMap();
			CreateMap<ResourceIdentifierDto, UserDto>().ReverseMap();
			CreateMap<UsersDto, Users>().ReverseMap();
			CreateMap<UserDto, Users>().ReverseMap();
			CreateMap<AccessTypeMaster, UsersDto>().ReverseMap();
			CreateMap<AccessTypeMaster, UserDto>().ReverseMap();
			CreateMap<CertificationDetailsDto, CertificationDetails>().ReverseMap();

			CreateMap<UsersDto, Users>()
				.ForMember(destination => destination.AccessTypeID, opt => opt.MapFrom(src => src.RoleID));

			CreateMap<Users, UsersDto>()
				.ForMember(destination => destination.RoleID, opt => opt.MapFrom(src => src.AccessTypeID))
				.ForPath(destination => destination.Role, opt => opt.MapFrom(src => src.AccessType!.Name));

			CreateMap<UserDto, Users>()
				 .ForMember(destination => destination.AccessTypeID, opt => opt.MapFrom(src => src.RoleID));

			CreateMap<Users, UserDto>()
				 .ForMember(destination => destination.RoleID, opt => opt.MapFrom(src => src.AccessTypeID))
				.ForPath(destination => destination.Role, opt => opt.MapFrom(src => src.AccessType!.Name));

			CreateMap<PublicHolidayDto, PublicHolidayMaster>().ReverseMap();
			CreateMap<SupplierDto, Supplier>();
			CreateMap<ContactInformationDto, ContactInformation>().ReverseMap();
			CreateMap<ManagerDto, Manager>().ReverseMap();

			CreateMap<Supplier, SupplierDto>()
				.ForMember(destination => destination.ContactInformation, opt => opt.MapFrom(src => src.ContactInformation));

			CreateMap<ResourceInformation, ResourceInformationDto>();
			CreateMap<CertificationDetails, ResourceInformationDto>();
			CreateMap<PersonalDetails, ResourceInformationDto>();
			CreateMap<ProfessionalDetails, ResourceInformationDto>();
			CreateMap<AcademicDetails, ResourceInformationDto>();
			CreateMap<Documents, ResourceInformationDto>();


			CreateMap<ResourceInformationDto, ResourceInformation>();
			CreateMap <CertificationDetailsDto, ResourceInformation>();

			CreateMap<ResourceInformationDto, ResourceInformation>()
				.ForMember(destination => destination.AcademicDetails, opt => opt.MapFrom(src => src.Academic))
				.ForMember(destination => destination.Documents, opt => opt.MapFrom(src => src.Documents))
				.ForMember(destination => destination.Professional, opt => opt.MapFrom(src => src.Professional))
				.ForMember(destination => destination.Personal, opt => opt.MapFrom(src => src.Personal))
				.ForMember(destination => destination.Certifications, opt => opt.MapFrom(src => src.Certification));


			CreateMap<DomainRoleMappingDto, DomainRoleMapping>().ReverseMap();
			CreateMap<ProjectBaseLineDto, ProjectBaseLine>();

			CreateMap<ProjectBaseLine, ProjectBaseLineDto>()
				.ForMember(destination => destination.ProjectName, opt => opt.MapFrom(src => src.Project != null ? src.Project.Name : string.Empty))
				.ForMember(destination => destination.LogoName, opt => opt.MapFrom(src => src.Client != null ? src.Client.Name : string.Empty))
				.ForMember(destination => destination.DomainName, opt => opt.MapFrom(src => src.Domain != null ? src.Domain.Name : string.Empty))
				.ForMember(destination => destination.RoleName, opt => opt.MapFrom(src => src.DomainRole != null ? src.DomainRole.Name : string.Empty))
				.ForMember(destination => destination.LevelName, opt => opt.MapFrom(src => src.DomainLevel != null ? src.DomainLevel.Name : string.Empty));



			CreateMap<ClientReportsDto, ClientReports>().ReverseMap();
			CreateMap<SupplierReportsDto, SupplierReports>().ReverseMap();
			CreateMap<ResourceReportsDto, ResourceReports>().ReverseMap();

		}
	}
}
