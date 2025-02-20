namespace RMT_API.Models
{
	public class DashboardDetails 
	{
		public ResourceCountDetails ResourceCountDetails { get; set; }
		public IEnumerable<ClientDetails> ClientDetails { get; set; }
		public IEnumerable<ProjectDetails> ProjectDetails { get; set; }
		public IEnumerable<SupplierDetails> SupplierDetails { get; set; }
		public IEnumerable<ResourceAttritionDetails> ResourceAttritionDetails { get; set; }
		public IEnumerable<ResourceOnboardingDetails> ResourceOnboardingDetails { get; set; }
		public IEnumerable<TimesheetPendingApprovals> TimesheetPendings { get; set; }
	}

	public class ResourceCountDetails {
		public int TotalResourceCount { get; set; }
		public int ActiveResourceCount { get; set; }
		public int InactiveResourceCount { get; set; }
	}

	public class ClientDetails : ResourceCountDetails
	{
		public string ClientName { get; set; }
	}

	public class ProjectDetails : ResourceCountDetails
	{ 
		public string ProjectName { get; set; }
	}

	public class SupplierDetails : ResourceCountDetails
	{
		public string SupplierName { get; set; }
	}

	public class ResourceAttritionDetails
	{
		public string InactiveMonth { get; set; }
		public int Count { get; set; }
	}

	public class ResourceOnboardingDetails
	{
		public string ActiveMonth { get; set; }
		public int Count { get; set; }
	}

	public class TimesheetPendingApprovals
	{
		public string Name { get; set; }
		public int ResourceID { get; set; }
		public int TimesheetID { get; set; }
		public string TimesheetCode { get; set; }
		public DateTime WeekStartDate { get; set; }
		public DateTime WeekEndDate { get; set; }
	}
}
