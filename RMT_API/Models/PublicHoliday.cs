using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class PublicHoliday : BaseModel
	{
		public bool? IsPublic { get; set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
	}
}
