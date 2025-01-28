using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class DomainLevel
	{
		[Key]
		public int LevelID { get; set; }
		public string? LevelName { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
