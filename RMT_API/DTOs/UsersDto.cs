using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class UsersDto :ResourceIdentifierDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public int? RoleID { get; set; }
		public string? Role { get; set; }
	}

	public class UserDto : ResourceIdentifierDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? UserName { get; set; }
		public int? RoleID { get; set; }
		public string? Role { get; set; }
	}
}
