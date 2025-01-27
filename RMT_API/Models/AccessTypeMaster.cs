using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class AccessTypeMaster
	{
		[Key]
		public int AccessTypeID { get; set; }
		public string? AccessTypeName { get; set; }
		public bool? IsActive { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
