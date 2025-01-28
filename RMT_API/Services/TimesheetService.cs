using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class TimesheetsService(IGenericRepository<Timesheet> _repository,
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
			var response = await _repository.GetAllAsync();
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
	}
}
