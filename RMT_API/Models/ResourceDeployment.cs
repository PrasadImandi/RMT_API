using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class ResourceDeployment
	{
		[Key]
		public int DeploymentID { get; set; }
		public int ResourceID { get; set; }
		public int ProjectID { get; set; }
		public string? Role { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Status { get; set; }
		public decimal AllocationPercent { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
