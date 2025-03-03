using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ProjectBaseLineDto : ResourceIdentifierDto
	{
		public int LogoID { get; set; }
		public int ProjectID { get; set; }
		public string? Type { get; set; }
		public int DomainID { get; set; }
		public int RoleID { get; set; }
		public int LevelID { get; set; }
		public int Baseline { get; set; }
		public string? DomainNameAsPerCustomer { get; set; }
		public string? Notes { get; set; }


		public string? LogoName { get; set; }
		public string? ProjectName { get; set; }
		public string? DomainName { get; set; }
		public string? RoleName { get; set; }
		public string? LevelName { get; set; }
	}
}
