using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ResourceInformation
	{
		[Key]
		public int ResourceInformationID { get; set; }
		public int ResourceID { get; set; }
		public PersonalDetails? Personal { get; set; } = new();
		public ProfessionalDetails? Professional {  get; set; } = new();
		public Documents Documents { get; set; } = new();
		public List<AcademicDetails>? Academic { get; set; } = [];
		public List<CertificationDetails>? Certification { get; set; } = [];

		// Created and updated info
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
