using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ClientDto :BaseDto
	{
		public string? ClientCode { get; set; }
		public string? ShortName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Address { get; set; }
		public string? Notes { get; set; }

		public string? RegionName { get; set; }
		public string? StateName { get; set; }
		public string? LocationName { get; set; }
		public string? Pincode { get; set; }
		public string? SPOCName { get; set; }

		public int RegionID { get; set; }
		public int StateID { get; set; }
		public int LocationID { get; set; }
		public int PincodeID { get; set; }
		public int? SPOCID { get; set; }
	}
}
