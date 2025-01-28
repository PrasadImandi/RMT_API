using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Timesheet
	{
		[Key]
		public int TimesheetID { get; set; }
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public DateTime Date { get; set; }
		public decimal HoursWorked { get; set; }
		public string? Notes { get; set; }
		public string? Status { get; set; }
		public DateTime? Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
