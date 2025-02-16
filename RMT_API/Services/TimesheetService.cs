using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;


namespace RMT_API.Services
{
	public class TimesheetsService(IGenericRepository<Timesheet> _repository,
		ITimesheetRepository _timesheetRepository,
		IMapper _mapper) : ITimesheetsService
	{
		public async Task AddTimesheetAsync(TimesheetDto timesheet)
		{
			await _repository.AddAsync(_mapper.Map<Timesheet>(timesheet));
		}

		public async Task DeleteTimesheetAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<TimesheetDto>> GetAllTimesheetsAsync()
		{
			var response = await _repository.GetAllWithChildrenAsync(query => query.Include(p => p.ProjectTimesheetDetails)
																					 .ThenInclude(dm => dm.TimesheetDetails)
																					 );
			return _mapper.Map<IEnumerable<TimesheetDto>>(response);
		}

		public async Task<TimesheetDto> GetTimesheetByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<TimesheetDto>(response);
		}

		public async Task UpdateTimesheetAsync(TimesheetDto timesheet)
		{
			await _repository.UpdateAsync(_mapper.Map<Timesheet>(timesheet));
		}

		public async Task ChangeStatusTimesheetAsync(TimesheetDto timesheet)
		{
			await _repository.ChangeStatusAsync(timesheet.ID, timesheet.IsActive);
		}

		public async Task<Timesheet> GetWeekTimesheetByStartDate(int resourceId, DateTime startOfWeek)
		{
			return await _timesheetRepository.GetNextWeekTimesheet(resourceId, startOfWeek);
		}

		//public async Task<Timesheet> GetCurrentWeekTimesheet(int resourceId)
		//{
		//	return await _timesheetRepository.GetCurrentWeekTimesheet(resourceId);
		//}
		//public async Task<Timesheet> GetPreviousWeekTimesheet(int resourceId, DateTime startOfWeek)
		//{
		//	return await _timesheetRepository.GetPreviousWeekTimesheet(resourceId, startOfWeek);
		//}
	}
}
