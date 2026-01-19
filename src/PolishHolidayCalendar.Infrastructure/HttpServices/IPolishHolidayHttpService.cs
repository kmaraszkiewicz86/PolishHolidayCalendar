using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Infrastructure.HttpServices;

public interface IPolishHolidayHttpService
{
    Task<IEnumerable<PublicHoliday>> GetPublicHolidaysAsync(int year, string countryCode);
}
