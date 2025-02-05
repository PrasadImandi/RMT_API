using RMT_API.DTOs.BaseDtos;
using RMT_API.Models;

namespace RMT_API.DTOs
{
	public class SupplierDto :BaseDto
	{
		public string? Supplier_Code { get; set; }
		public DateTime? SIDDate { get; set; }
		public string? Address { get; set; }
		public int? StateID { get; set; }
		public string? GST { get; set; }
		public string? PAN { get; set; }
		public string? TAN { get; set; }
		public string? StateName { get; set; }
		public virtual ICollection<ContactInformation>? ContactInformation { get; set; } = [];

	}
}
