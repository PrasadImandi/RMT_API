using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ResourceInformation :BaseModel
	{
		public int ResourceID { get; set; }
		public PersonalDetails? Personal { get; set; } = new();
		public ProfessionalDetails? Professional {  get; set; } = new();
		public Documents Documents { get; set; } = new();
		public List<AcademicDetails>? Academic { get; set; } = [];
		public List<CertificationDetails>? Certification { get; set; } = [];
	}
}
