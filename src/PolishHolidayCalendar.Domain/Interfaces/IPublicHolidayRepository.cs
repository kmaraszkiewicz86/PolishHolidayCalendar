using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Domain.Interfaces;

public interface IPublicHolidayRepository
{
    void Save(IEnumerable<PublicHoliday> holidays);
}
