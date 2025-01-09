﻿using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IResourceLifecyclesService
	{
		Task<IEnumerable<ResourceLifeCycleDto>> GetAllResourceLifecyclesAsync();
		Task<ResourceLifeCycleDto> GetResourceLifecycleByIdAsync(int id);
		Task AddResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle);
		Task UpdateResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle);
		Task DeleteResourceLifecycleAsync(int id);
		Task ChangeStatusResourceLifecycleAsync(ResourceLifeCycleDto resourceLifecycle);
	}
}