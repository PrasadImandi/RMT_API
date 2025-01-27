namespace RMT_API.DTOs
{
	public class FormDto
	{
		public int FormID { get; set; }
		public string? FormName { get; set; }
		public string? FormDescription { get; set; }
		public bool IsActive { get; set; }
	}
}
