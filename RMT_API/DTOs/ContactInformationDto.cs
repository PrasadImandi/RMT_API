namespace RMT_API.DTOs
{
	public class ContactInformationDto
	{
		public int ContactInformationID { get; set; }
		public int ContactTypeID { get; set; }
		public string? ContactName { get; set; }
		public string? ContactNumber { get; set; }
		public string? ContactEmail { get; set; }
	}
}
