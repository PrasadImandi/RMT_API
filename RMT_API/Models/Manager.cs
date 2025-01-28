using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Manager : BaseModel
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ContactNumber { get; set; }
		public string? EmailID { get; set; }
		public int? ProjectManagerID { get; set; }
		public virtual Manager? ProjectManager { get; set; } = new();
	}
}
