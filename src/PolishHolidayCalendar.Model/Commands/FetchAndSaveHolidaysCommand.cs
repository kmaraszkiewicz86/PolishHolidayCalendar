using SimpleCqrs;

namespace PolishHolidayCalendar.Model.Commands;

public record FetchAndSaveHolidaysCommand(int Year, string CountryCode) : ICommand<VoidResult>;
