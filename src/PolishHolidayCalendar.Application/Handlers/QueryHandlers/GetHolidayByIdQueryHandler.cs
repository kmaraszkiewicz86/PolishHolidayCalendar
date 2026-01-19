using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Queries;
using PolishHolidayCalendar.Model.Queries;
using SimpleCqrs;

namespace PolishHolidayCalendar.Application.Handlers.QueryHandlers;

public class GetHolidayByIdQueryHandler : IAsyncQueryHandler<GetHolidayByIdQuery, PublicHoliday?>
{
    private readonly IPublicHolidayQuery _query;

    public GetHolidayByIdQueryHandler(IPublicHolidayQuery query)
    {
        _query = query;
    }

    public async Task<PublicHoliday?> HandleAsync(GetHolidayByIdQuery query, CancellationToken cancellationToken)
    {
        return await _query.GetByIdAsync(query.Id);
    }
}
