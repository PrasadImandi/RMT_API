﻿using RMT_API.Models;

namespace RMT_API.Repositories
{
	public interface IResourceRepository
	{
		Task ChangeStatusResource(Resource resource);
		
	}
}