using PolishHolidayCalendar.Domain.Repositories;
using PolishHolidayCalendar.Infrastructure.Database;

namespace PolishHolidayCalendar.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly PublicHolidayDbContext _context;

    public UnitOfWork(PublicHolidayDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
