using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Supplier : BaseModel
	{
		public string? Supplier_Code { get; set; }
		public DateTime? SIDDate { get; set; }
		public string? Address { get; set; }
		public int? StateID { get; set; }
		public string? GST { get; set; }
		public string? PAN { get; set; }
		public string? TAN { get; set; }
		public int? ContactInformationID { get; set; }

		public virtual ContactInformation? ContactInformation { get; set; } = new();
	}
}
