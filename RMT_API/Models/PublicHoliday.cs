using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class PublicHoliday
	{
		[Key]
		public int PHID { get; set; }
		public string? PHName { get; set; }
		public string? PHDescription { get; set; }
		public bool? IsPublic { get; set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
