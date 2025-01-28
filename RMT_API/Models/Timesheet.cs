using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Timesheet : BaseModel
	{
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public DateTime Date { get; set; }
		public decimal HoursWorked { get; set; }
		public string? Notes { get; set; }
	}
}
