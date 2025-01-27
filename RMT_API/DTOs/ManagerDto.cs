namespace RMT_API.DTOs
{
	public class ManagerDto
	{
		public int ManagerID { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ContactNumber { get; set; }
		public string? EmailID { get; set; }
		public bool? IsActive { get; set; }
		public int? ProjectManagerID { get; set; }
	}
}
