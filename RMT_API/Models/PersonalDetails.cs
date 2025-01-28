using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class PersonalDetails : BaseModel
	{
		public int Gender { get; set; }
		public string? FathersName { get; set; }
		public string? MothersName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? AlternateContactNumber { get; set; }
		public string? EmergencyContactNumber { get; set; }
		public string? HometownAddress { get; set; }
		public DateTime JoiningDate { get; set; }
		public string? OfficialMailingAddress { get; set; }
		public string? PinCode { get; set; }
		public int? StateID { get; set; }
		public int ResourceInformationId { get; set; }
	}
}
