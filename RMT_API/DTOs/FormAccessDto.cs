using RMT_API.DTOs.BaseDtos;

namespace RMT_API.DTOs
{
	public class FormAccessDto :ResourceIdentifierDto
	{
		public int AccessTypeID { get; set; }
		public int FormID { get; set; }
	}
}
