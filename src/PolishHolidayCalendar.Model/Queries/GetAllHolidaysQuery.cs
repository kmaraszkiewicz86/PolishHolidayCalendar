using PolishHolidayCalendar.Domain.Entities;
using SimpleCqrs;

namespace PolishHolidayCalendar.Model.Queries;

public record GetAllHolidaysQuery : IQuery<IEnumerable<PublicHoliday>>;
