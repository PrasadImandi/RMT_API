using RMT_API.DTOs;

namespace RMT_API.Services
{
	public interface IPublicHolidaysService
	{
		Task AddPublicHolidayAsync(PublicHolidayDto publicHoliday);

		Task DeletePublicHolidayAsync(int id);

		Task<IEnumerable<PublicHolidayDto>> GetAllPublicHolidaysAsync(string searchText, int pageNumber, int pageSize);

		Task<PublicHolidayDto> GetPublicHolidayByIdAsync(int id);

		Task UpdatePublicHolidayAsync(PublicHolidayDto publicHoliday);

	}
}
