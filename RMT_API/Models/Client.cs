using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class Client : BaseModel
	{
		public string? ShortName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Address { get; set; }
		public string? Notes { get; set; }


		public int RegionID { get; set; }
		public int StateID { get; set; }
		public int LocationID { get; set; }
		public int PincodeID { get; set; }
		public int? SPOCID { get; set; }
	}
}
