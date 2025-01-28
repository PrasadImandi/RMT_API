using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RMT_API.Models
{
	public class Users
	{
		[Key]
		public int UserID { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public int? AccessTypeID { get; set; }
		public bool IsActive { get; set; }
		public DateTime Created_Date { get; set; }
		public int? Created_By { get; set; }
		public DateTime? Updated_Date { get; set; }
		public int? Updated_By { get; set; }

		//[Ignore]
		//// Navigation property for the foreign key reference
		//public AccessTypeMaster? AccessTypeMaster { get; set; }
	}
}
