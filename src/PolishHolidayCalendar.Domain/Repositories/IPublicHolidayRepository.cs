using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Domain.Repositories;

public interface IPublicHolidayRepository
{
    Task SaveAsync(IEnumerable<PublicHoliday> holidays);
}
