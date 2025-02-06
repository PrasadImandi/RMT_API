using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ContactInformation :BaseModel
	{
		public int ContactTypeID { get; set; }
		public string? ContactNumber { get; set; }
		public string? ContactEmail { get; set; }

		public int SupplierID { get;set; }

		public virtual ContactTypeMaster? ContactType { get; set; }
	}
}
