using PolishHolidayCalendar.Domain.Services;
using PolishHolidayCalendar.Infrastructure.HttpServices;
using PolishHolidayCalendar.Model.Commands;
using SimpleCqrs;

namespace PolishHolidayCalendar.Application.Handlers.CommandHandlers;

public class FetchAndSaveHolidaysCommandHandler : IAsyncCommandHandler<FetchAndSaveHolidaysCommand, VoidResult>
{
    private readonly IPolishHolidayHttpService _httpService;
    private readonly PublicHolidayService _service;

    public FetchAndSaveHolidaysCommandHandler(IPolishHolidayHttpService httpService, PublicHolidayService service)
    {
        _httpService = httpService;
        _service = service;
    }

    public async Task<VoidResult> HandleAsync(FetchAndSaveHolidaysCommand command, CancellationToken cancellationToken)
    {
        var holidays = await _httpService.GetPublicHolidaysAsync(command.Year, command.CountryCode);
        await _service.SaveHolidaysAsync(holidays);
        return new VoidResult();
    }
}
