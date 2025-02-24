namespace RMT_API.DTOs.BaseDtos
{
	public class BaseDto : ResourceIdentifierDto
	{
		public string? Name { get; set; }



		////// Additional fields Required in the case of Masters Creation
		public int? DomainID { get; set; }
	}
}
