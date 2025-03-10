﻿using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IProjectBaseLineService
	{
		Task<IEnumerable<ProjectBaseLineDto>> GetAllProjectBaseLinesAsync(string? searchText, int? pageNumber, int? pageSize);
		Task<ProjectBaseLineDto> GetProjectBaseLineByIdAsync(int id);
		Task AddProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine);
		Task UpdateProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine);
		Task DeleteProjectBaseLineAsync(int id);
		Task ChangeStatusProjectBaseLineAsync(ProjectBaseLineDto projectBaseLine);
	}
}
