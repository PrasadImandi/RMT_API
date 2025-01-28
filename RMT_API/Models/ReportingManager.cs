using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ReportingManager
	{
		[Key]
		public int ReportingManagerID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }
		public int? ProjectManagerID { get; set; }
		public string? RMName { get; set; }
		public string? RMContactNumber { get; set; }
		public string? RMEmailID { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		// Navigation properties for foreign keys
		public Client? ClientMaster { get; set; }
		public Project? ProjectMaster { get; set; }
		public Manager? ProjectManager { get; set; }
	}
}
