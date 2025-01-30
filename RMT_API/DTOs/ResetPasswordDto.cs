namespace RMT_API.DTOs
{
	public class ResetPasswordDto
	{
		public string? OldPassword { get; set; }
		public string? NewPassword { get; set; }
		public string? UserName { get; set; }
	}
}
