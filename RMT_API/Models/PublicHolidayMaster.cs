using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class PublicHolidayMaster : BaseModel
	{
		public string? Description { get; set; }
		public bool? IsPublic { get; set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
	}
}
