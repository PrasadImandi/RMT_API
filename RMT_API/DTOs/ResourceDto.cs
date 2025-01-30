using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ResourceDto :BaseDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? MobileNumber { get; set; }
		public string? EmailID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }
		public int? PMID { get; set; }
		public int? RMID { get; set; }
		public int? SupplierID { get; set; }
		public int? ResourceInformationID { get; set; }
	}
}
