using AutoMapper;
using RMT_API.DTOs;
using RMT_API.Models;
using RMT_API.Repositories;

namespace RMT_API.Services
{
	public class PublicHolidaysService(IGenericRepository<PublicHolidayMaster> _repository, IMapper _mapper) : IPublicHolidaysService
	{
		public async Task AddPublicHolidayAsync(PublicHolidayDto publicHoliday)
		{
			await _repository.AddAsync(_mapper.Map<PublicHolidayMaster>(publicHoliday));
		}

		public async Task DeletePublicHolidayAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<PublicHolidayDto>> GetAllPublicHolidaysAsync(string searchText, int pageNumber, int pageSize)
		{
			var response = await _repository.GetAllAsync(query => query.Where(p => p.Name!.Contains(searchText))
			.Skip(pageNumber * pageSize)
			.Take(pageSize));
			return _mapper.Map<IEnumerable<PublicHolidayDto>>(response);
		}

		public async Task<PublicHolidayDto> GetPublicHolidayByIdAsync(int id)
		{
			var response = await _repository.GetByIdAsync(id);
			return _mapper.Map<PublicHolidayDto>(response);
		}

		public async Task UpdatePublicHolidayAsync(PublicHolidayDto publicHoliday)
		{
			await _repository.UpdateAsync(_mapper.Map<PublicHolidayMaster>(publicHoliday));
		}
	}
}
