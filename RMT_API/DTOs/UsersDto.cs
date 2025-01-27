namespace RMT_API.DTOs
{
	public class UsersDto
	{
		public int UserID { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public int? AccessTypeID { get; set; }
		public bool IsActive { get; set; }
	}
}
