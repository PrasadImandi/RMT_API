using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ProfessionalDetails : BaseModel
	{
		public DateTime? AssetAssignedDate { get; set; }
		public string? AssetModelNo { get; set; }
		public string? AssetSerialNo { get; set; }
		public bool AttendanceRequired { get; set; }
		public string? CWFID { get; set; }
		public DateTime? LastWorkingDate { get; set; }
		public string? OfficialEmailID { get; set; }
		public int OverallExperience { get; set; }
		public DateTime? PODate { get; set; }
		public string? PONo { get; set; }
		public DateTime JoiningDate { get; set; }


		public int? JoiningLocationID { get; set; }
		public int? LaptopProviderID { get; set; }
		public int? DomainID { get; set; }
		public int? DomainRoleID { get; set; }
		public int? DomainLevelID { get; set; }
		public int ResourceInformationId { get; set; }

	}
}
