using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ResourceInformation :BaseModel
	{
		public int ResourceID { get; set; }


		public virtual PersonalDetails? Personal { get; set; } 
		public virtual ProfessionalDetails? Professional {  get; set; }
		public virtual Documents? Documents { get; set; }


		public virtual ICollection<AcademicDetails>? AcademicDetails { get; set; } 
		public virtual ICollection<CertificationDetails>? Certifications { get; set; }
	}
}
