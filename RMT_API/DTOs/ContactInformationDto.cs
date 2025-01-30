using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ContactInformationDto :BaseDto
	{
		public int ContactTypeID { get; set; }
		public string? ContactNumber { get; set; }
		public string? ContactEmail { get; set; }
	}
}
