using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class SPOC
	{
		[Key]
		public int SPOCID { get; set; }
		public string? SPOCName { get; set; }
		public string? SPOCContactNumber { get; set; }
		public string? SPOCEmailID { get; set; }
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
