using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Queries;
using PolishHolidayCalendar.Model.Queries;
using SimpleCqrs;

namespace PolishHolidayCalendar.Application.Handlers.QueryHandlers;

public class GetAllHolidaysQueryHandler : IAsyncQueryHandler<GetAllHolidaysQuery, IEnumerable<PublicHoliday>>
{
    private readonly IPublicHolidayQuery _query;

    public GetAllHolidaysQueryHandler(IPublicHolidayQuery query)
    {
        _query = query;
    }

    public async Task<IEnumerable<PublicHoliday>> HandleAsync(GetAllHolidaysQuery query, CancellationToken cancellationToken)
    {
        return await _query.GetAllAsync();
    }
}
