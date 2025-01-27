using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ContactInformation
	{
		[Key]
		public int ContactInformationID { get; set; }
		public int ContactTypeID { get; set; }
		public string? ContactName { get; set; }
		public string? ContactNumber { get; set; }
		public string? ContactEmail { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		// Navigation property for the foreign key reference
		public ContactType? ContactTypeMaster { get; set; }
	}
}
