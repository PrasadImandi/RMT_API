﻿using RMT_API.Models.BaseModels;

namespace RMT_API.Models
{
	public class DomainRoleMaster : BaseModel
	{
		public int? DomainID { get; set; }
		public virtual DomainMaster? Domain {  get; set; }
	}
}
