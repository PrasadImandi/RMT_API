namespace RMT_API.Models
{
	public class Documents
	{
		public int Id { get; set; }
		public int ResourceInformationId { get; set; }

		public List<BGVDocuments> BGV { get; set; } = new();
		public List<JoiningDocuments> Joining { get; set; } = new();
	}
}
