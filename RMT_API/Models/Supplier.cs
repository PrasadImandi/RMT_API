using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Supplier
	{
		[Key]
		public int SupplierID { get; set; }
		public string? SupplierName { get; set; }
		public DateTime? SIDDate { get; set; }
		public string? Address { get; set; }
		public int? StateID { get; set; }
		public string? GST { get; set; }
		public string? PAN { get; set; }
		public string? TAN { get; set; }
		public bool? IsActive { get; set; }
		public int? ContactInfoID { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		// Navigation properties for foreign keys
		public State? State { get; set; }
		public ContactInformation? ContactInformation { get; set; }
	}
}
