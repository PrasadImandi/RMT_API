using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ProfessionalDetails
	{
		[Key]
		public int Id { get; set; }
		public DateTime? AssetAssignedDate { get; set; }
		public string? AssetModelNo { get; set; }
		public string? AssetSerialNo { get; set; }
		public bool AttendanceRequired { get; set; }
		public string? CWFID { get; set; }
		public int? DomainID { get; set; }
		public int? Laptop { get; set; }
		public DateTime? LastWorkingDate { get; set; }
		public int? LevelID { get; set; }
		public string? OfficialEmailID { get; set; }
		public int OverallExperience { get; set; }
		public DateTime? PODate { get; set; }
		public int? RoleID { get; set; }
		public string? PONo { get; set; }
		public int ResourceInformationId { get; set; }

	}
}
