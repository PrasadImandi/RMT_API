namespace RMT_API.DTOs
{
	public class TimesheetDto :BaseDto
	{ 
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public DateTime Date { get; set; }
		public decimal HoursWorked { get; set; }
		public string? Notes { get; set; }
	}
}
