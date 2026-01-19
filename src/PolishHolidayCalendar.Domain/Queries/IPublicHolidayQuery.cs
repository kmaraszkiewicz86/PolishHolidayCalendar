using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Domain.Queries;

public interface IPublicHolidayQuery
{
    Task<IEnumerable<PublicHoliday>> GetAllAsync();
    Task<IEnumerable<PublicHoliday>> GetByYearAsync(int year);
    Task<PublicHoliday?> GetByIdAsync(int id);
}
