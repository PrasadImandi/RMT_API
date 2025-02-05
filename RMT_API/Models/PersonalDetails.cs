using RMT_API.Models.BaseModels;
using System.Text.Json.Serialization;

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
		public string? OfficialMailingAddress { get; set; }

		public int? PinCodeID { get; set; }
		public int? StateID { get; set; }


		public int ResourceInformationID { get; set; }
		[JsonIgnore]
		public virtual ResourceInformation? ResourceInformation { get; set; }
	}
}
