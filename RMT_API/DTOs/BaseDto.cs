namespace RMT_API.DTOs
{
	public class BaseDto
	{
		public int ID{ get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? IsActive { get; set; }
	}
}
