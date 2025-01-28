using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Project : BaseModel
	{
		public int? ClientID { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
