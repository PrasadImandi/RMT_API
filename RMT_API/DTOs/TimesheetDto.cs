namespace RMT_API.DTOs
{
	public class TimesheetDto
	{
		public int TimesheetID { get; set; }
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public DateTime Date { get; set; }
		public decimal HoursWorked { get; set; }
		public string? Notes { get; set; }
	}
}
