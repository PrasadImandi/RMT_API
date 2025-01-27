using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Manager
	{
		[Key]
		public int ManagerID { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ContactNumber { get; set; }
		public string? EmailID { get; set; }
		public bool? IsActive { get; set; }
		public int? ProjectManagerID { get; set; }
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		// Navigation property for the self-referencing foreign key (ProjectManagerID)
		public Manager? ProjectManager { get; set; }
	}
}
