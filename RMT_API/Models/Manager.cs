using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Manager : ResourceIdentifier
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ContactNumber { get; set; }
		public string? EmailID { get; set; }
		public int? ManagerType { get; set; }

		public int? ParentManagerId { get; set; }
		public Manager? ParentManager { get; set; }
	}
}
