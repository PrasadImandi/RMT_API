using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ManagerDto :ResourceIdentifierDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ContactNumber { get; set; }
		public string? EmailID { get; set; }
		public int? ProjectManagerID { get; set; }
	}
}
