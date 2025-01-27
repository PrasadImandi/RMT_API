namespace RMT_API.Models
{
	public class ContactType
	{
		public int ContactTypeID { get; set; }
		public string? ContactTypeName { get; set; }
		public bool? IsActive { get; set; }
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
