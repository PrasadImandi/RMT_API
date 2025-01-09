﻿namespace RMT_API.DTOs
{
	public class PublicHolidayDto
	{
		public int PHID { get; set; }
		public string? PHName { get; set; }
		public DateTime PHDate { get; set; }
		public DateTime PHYear { get; set; }
		public DateTime Created_Date { get; set; }
		public int Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
