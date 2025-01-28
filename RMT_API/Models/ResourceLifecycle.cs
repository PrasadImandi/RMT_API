using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ResourceLifecycle :BaseModel
	{
		public int ResourceID { get; set; }
		public string? LifecycleType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? Notes { get; set; }
		public int HandledByID { get; set; }
	}
}
