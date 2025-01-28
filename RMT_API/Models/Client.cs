using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Client
	{
		[Key]
		public int ClientID { get; set; }
		public string? LogoName { get; set; }
		public string? ShortName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Address { get; set; }

		public int RegionID { get; set; }
		public int StateID { get; set; }
		public int LocationID { get; set; }
		public int PincodeID { get; set; }

		public int? SPOCID { get; set; }
		public string Notes { get; set; }
		public bool? IsActive { get; set; }
		public DateTime? Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

	}
}
