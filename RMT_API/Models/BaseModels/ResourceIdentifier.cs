using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RMT_API.Models.BaseModels
{
	public class ResourceIdentifier
	{
		[Key]
		public int ID { get; set; }

		public bool? IsActive { get; set; }

		[JsonIgnore]
		public DateTime? Created_Date { get; set; } = new DateTime();
		[JsonIgnore]
		public int? Created_By { get; set; }
		[JsonIgnore]
		public DateTime? Updated_Date { get; set; }
		[JsonIgnore]
		public int? Updated_By { get; set; }
	}
}
