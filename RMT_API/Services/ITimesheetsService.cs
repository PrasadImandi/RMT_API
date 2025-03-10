﻿using RMT_API.DTOs;
using RMT_API.Models;

namespace RMT_API.Services
{
	public interface ITimesheetsService
	{
		Task<IEnumerable<TimesheetDto>> GetAllTimesheetsAsync(string searchText, int pageNumber, int pageSize);
		Task<TimesheetDto> GetTimesheetByIdAsync(int id);
		Task AddTimesheetAsync(TimesheetDto timesheet);
		Task UpdateTimesheetAsync(TimesheetDto timesheet);
		Task DeleteTimesheetAsync(int id);
		Task ChangeStatusTimesheetAsync(TimesheetDto timesheet);
		Task<TimesheetDto> GetWeekTimesheetByStartDate(int resourceId, DateTime startOfWeek);


		Task ApproveTimesheetAsync(TimesheetDto timesheet);

	}
}
