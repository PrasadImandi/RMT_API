using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Resource
	{
		[Key]
		public int ResourceID { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? MobileNumber { get; set; }
		public string? EmailID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }
		public int? PMID { get; set; }
		public int? RMID { get; set; }
		public bool? IsActive { get; set; }
		public int? SupplierID { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		public int? ResourceInformationID { get; set; }
		public ResourceInformation? ResourceInformation { get; set; }

	}
}
