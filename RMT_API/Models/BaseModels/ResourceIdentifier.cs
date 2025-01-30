using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models.BaseModels
{
	public class ResourceIdentifier
	{
		[Key]
		public int ID { get; set; }

		public bool? IsActive { get; set; }
		public DateTime? Created_Date { get; set; } = new DateTime();
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
