namespace RMT_API.DTOs
{
	public class ResourceDto
	{
		public int ResourceID { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? JobTitle { get; set; }
		public DateTime? HireDate { get; set; }
		public string? Status { get; set; }
		public int DepartmentID { get; set; }
		public int? ManagerID { get; set; }
	    public bool? IsActive { get; set; }
	}
}
