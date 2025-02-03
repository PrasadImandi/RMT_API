using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class ReportingManager : BaseModel
	{
		public string? RMContactNumber { get; set; }
		public string? RMEmailID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }

		public int? ProjectManagerID { get; set; }
		public virtual List<Client>? Clients { get; set; } = [];
		public virtual List<Project>? Projects { get; set; } = [];
		public virtual Manager? ProjectManager { get; set; } = new();
	}
}
