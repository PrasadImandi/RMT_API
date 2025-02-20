using RMT_API.Models;

namespace RMT_API.DTOs
{
	public class ResourceInformationDto
	{
		public int ID { get; set; }
		public int ResourceID { get; set; }
		public Resource? ResourceDetails{ get; set; }
		public PersonalDetails? Personal { get; set; }
		public ProfessionalDetails? Professional { get; set; }
		public Documents? Documents { get; set; }
		public List<AcademicDetails>? Academic { get; set; } = [];
		public List<CertificationDetailsDto>? Certification { get; set; } = [];

	}
}
