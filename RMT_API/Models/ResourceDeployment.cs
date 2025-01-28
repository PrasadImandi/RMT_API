using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ResourceDeployment :BaseModel
	{
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public string? Role { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal AllocationPercent { get; set; }
	}
}
