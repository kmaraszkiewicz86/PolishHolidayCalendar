using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Domain.Interfaces;

public interface IHttpService
{
    Task<IEnumerable<PublicHoliday>> GetPublicHolidaysAsync(int year, string countryCode);
}
