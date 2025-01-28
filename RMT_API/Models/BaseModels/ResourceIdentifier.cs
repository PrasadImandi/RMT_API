using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models.BaseModels
{
	public class ResourceIdentifier
	{
		[Key]
		public int ID { get; set; }
	}
}
