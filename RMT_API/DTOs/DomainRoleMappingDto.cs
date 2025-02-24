using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class DomainRoleMappingDto :ResourceIdentifierDto
	{
		public int DomainID { get; set; }
		public int RoleID { get; set; }
	}
}
