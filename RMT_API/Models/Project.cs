using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Project
	{
		[Key]
		public int ProjectID { get; set; }
		public string? ProjectName { get; set; }
		public int? ClientID { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		// Navigation property
		public Client? ClientMaster { get; set; }
	}
}
