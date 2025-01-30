using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ProjectDto :BaseDto
	{
		public int ClientID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
