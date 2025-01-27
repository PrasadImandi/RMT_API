namespace RMT_API.Models
{
	public class ResourceInformation
	{
		public int ResourceInfoID { get; set; }
		public string? FullName { get; set; }
		public string? Mobile { get; set; }
		public string? PersonalMail { get; set; }
		public DateTime JoiningDate { get; set; }
		public int Gender { get; set; }
		public DateTime DOB { get; set; }
		public string? OfficialMailingAddress { get; set; }
		public string? PinCode { get; set; }
		public string? HometownAddress { get; set; }
		public string? AltContactNumber { get; set; }
		public string? EmergencyContactNumber { get; set; }
		public string? FathersName { get; set; }
		public string? MothersName { get; set; }
		public int OverallExperience { get; set; }
		public bool AttendanceRequired { get; set; }
		public string? CWFID { get; set; }
		public string? OfficialEmailID { get; set; }
		public int? Laptop { get; set; }
		public DateTime? AssetAssignedDate { get; set; }
		public string? AssetModelNo { get; set; }
		public string? AssetSerialNo { get; set; }
		public string? PONo { get; set; }
		public DateTime? PODate { get; set; }
		public DateTime? LastWorkingDate { get; set; }
		public bool IsActive { get; set; }

		// Foreign keys
		public int? StateID { get; set; }
		public int? JoiningLocationID { get; set; }
		public int? ProjectID { get; set; }
		public int? ReportingManagerID { get; set; }
		public int? SupplierID { get; set; }
		public int? DomainID { get; set; }
		public int? RoleID { get; set; }
		public int? LevelID { get; set; }
		public int ResourceID { get; set; }

		// Navigation properties for foreign key relations
		public State? State { get; set; }
		public Location? Location { get; set; }
		public Project? Project { get; set; }
		public ReportingManager? ReportingManager { get; set; }
		public Supplier? Supplier { get; set; }
		public Domain? Domain { get; set; }
		public DomainRole? DomainRole { get; set; }
		public DomainLevel? DomainLevel { get; set; }
		public Resource? Resource { get; set; }

		// Created and updated info
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }
	}
}
