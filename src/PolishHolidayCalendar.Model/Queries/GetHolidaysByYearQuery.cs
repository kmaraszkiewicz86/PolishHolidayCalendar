using PolishHolidayCalendar.Domain.Entities;
using SimpleCqrs;

namespace PolishHolidayCalendar.Model.Queries;

public record GetHolidaysByYearQuery(int Year) : IQuery<IEnumerable<PublicHoliday>>;
