namespace RMT_API.DTOs
{
	public class UsersDto
	{
		public int UserID { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? Role { get; set; }
		public int? RoleID { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
