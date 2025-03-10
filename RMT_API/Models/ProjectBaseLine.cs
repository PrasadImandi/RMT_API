using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

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
		public int? DeployedCount { get; set; }
		public int? AdditionalResource { get; set; }
		public int? NoticePeriod { get; set; }
		public int? ToBeHire { get; set; }


		[JsonIgnore]
		public virtual Project? Project { get; set; }

		[JsonIgnore]
		public virtual DomainMaster? Domain{ get; set; }

		[JsonIgnore]
		public virtual DomainRoleMaster? DomainRole { get; set; }

		[JsonIgnore]
		public virtual DomainLevelMaster? DomainLevel { get; set; }

		[JsonIgnore]
		public virtual Client? Client{ get; set; }
	}
}
