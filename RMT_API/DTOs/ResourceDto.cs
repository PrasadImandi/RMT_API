﻿using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class ResourceDto :ResourceIdentifierDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ResourceCode { get; set; }
		public string? MobileNumber { get; set; }
		public string? EmailID { get; set; }
		public int ClientID { get; set; }
		public int ProjectID { get; set; }
		public int? PMID { get; set; }
		public int? RMID { get; set; }
		public int? UserID { get; set; }
		public bool? IsAddUser { get; set; }
		public int? SupplierID { get; set; }
		public int? ResourceInformationID { get; set; }
	}
}
