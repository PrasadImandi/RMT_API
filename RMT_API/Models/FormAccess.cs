
using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class FormAccess : ResourceIdentifier
	{
		public int AccessTypeID { get; set; }
		public int FormID { get; set; }
	}
}
