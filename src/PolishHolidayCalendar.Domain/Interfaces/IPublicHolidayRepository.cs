using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Domain.Interfaces;

public interface IPublicHolidayRepository
{
    Task SaveAsync(IEnumerable<PublicHoliday> holidays);
}
