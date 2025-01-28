using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Pincode
	{
		[Key]
		public int PincodeID { get; set; }
		public string? Name { get; set; }
		public string? Code { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
