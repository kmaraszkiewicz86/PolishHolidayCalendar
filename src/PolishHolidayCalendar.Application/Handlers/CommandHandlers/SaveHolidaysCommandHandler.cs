using PolishHolidayCalendar.Domain.Services;
using PolishHolidayCalendar.Model.Commands;
using SimpleCqrs;

namespace PolishHolidayCalendar.Application.Handlers.CommandHandlers;

public class SaveHolidaysCommandHandler : IAsyncCommandHandler<SaveHolidaysCommand, VoidResult>
{
    private readonly PublicHolidayService _service;

    public SaveHolidaysCommandHandler(PublicHolidayService service)
    {
        _service = service;
    }

    public async Task<VoidResult> HandleAsync(SaveHolidaysCommand command, CancellationToken cancellationToken)
    {
        await _service.SaveHolidaysAsync(command.Holidays);
        return new VoidResult();
    }
}
