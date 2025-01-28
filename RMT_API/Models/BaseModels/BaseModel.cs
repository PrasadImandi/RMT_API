namespace RMT_API.Models.BaseModels
{
	public class BaseModel : ResourceIdentifier
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? Created_Date { get; set; } = new DateTime();
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

	}
}
