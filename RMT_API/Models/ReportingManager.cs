using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ReportingManager : BaseModel
	{
		public string? RMContactNumber { get; set; }
		public string? RMEmailID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }
		public int? PMID { get; set; }

		public virtual Client? ClientMaster { get; set; } = new();
		public virtual Project? ProjectMaster { get; set; } = new();
		public virtual Manager? ProjectManager { get; set; } = new();
	}
}
