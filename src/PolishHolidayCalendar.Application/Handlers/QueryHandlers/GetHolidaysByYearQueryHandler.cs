using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Queries;
using PolishHolidayCalendar.Model.Queries;
using SimpleCqrs;

namespace PolishHolidayCalendar.Application.Handlers.QueryHandlers;

public class GetHolidaysByYearQueryHandler : IAsyncQueryHandler<GetHolidaysByYearQuery, IEnumerable<PublicHoliday>>
{
    private readonly IPublicHolidayQuery _query;

    public GetHolidaysByYearQueryHandler(IPublicHolidayQuery query)
    {
        _query = query;
    }

    public async Task<IEnumerable<PublicHoliday>> HandleAsync(GetHolidaysByYearQuery query, CancellationToken cancellationToken)
    {
        return await _query.GetByYearAsync(query.Year);
    }
}
