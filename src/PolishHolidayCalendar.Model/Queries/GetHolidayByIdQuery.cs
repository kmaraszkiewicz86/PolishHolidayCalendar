using PolishHolidayCalendar.Domain.Entities;
using SimpleCqrs;

namespace PolishHolidayCalendar.Model.Queries;

public record GetHolidayByIdQuery(int Id) : IQuery<PublicHoliday?>;
