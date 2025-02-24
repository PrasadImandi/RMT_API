using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ProjectBaseLine : ResourceIdentifier
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
	}
}
