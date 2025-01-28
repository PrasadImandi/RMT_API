using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ResourceLifecycle
	{
		[Key]
		public int LifecycleID { get; set; }
		public int ResourceID { get; set; }
		public string? LifecycleType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string? Status { get; set; }
		public string? Notes { get; set; }
		public int HandledByID { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
