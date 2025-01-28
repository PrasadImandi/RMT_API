using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RMT_API.Models
{
	public class FormAccess
	{
		[Key]
		public int AccessID { get; set; }
		public int AccessTypeID { get; set; }
		public int FormID { get; set; }
		public bool IsActive { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

	}
}
