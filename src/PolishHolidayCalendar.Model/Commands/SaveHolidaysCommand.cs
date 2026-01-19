using PolishHolidayCalendar.Domain.Entities;
using SimpleCqrs;

namespace PolishHolidayCalendar.Model.Commands;

public record SaveHolidaysCommand(IEnumerable<PublicHoliday> Holidays) : ICommand<VoidResult>;
