using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Users : BaseModel
	{
		public string? Email { get; set; }
		public int? AccessTypeID { get; set; }

		public virtual AccessTypeMaster? AccessType { get; set; }
	}
}
