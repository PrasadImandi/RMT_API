using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Users : BaseModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public int? AccessTypeID { get; set; }

		public virtual AccessTypeMaster? AccessType { get; set; } = null;
	}
}
