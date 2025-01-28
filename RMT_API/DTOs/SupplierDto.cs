namespace RMT_API.DTOs
{
	public class SupplierDto :BaseDto
	{
		public string? ContactInfo { get; set; }
		public string? PAN { get; set; }
		public string? GST { get; set; }
		public string? PaymentTerms { get; set; }
	}
}
