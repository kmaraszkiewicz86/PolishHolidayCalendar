using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Infrastructure.Data;

namespace PolishHolidayCalendar.Infrastructure.Queries;

public class PublicHolidayQuery : IPublicHolidayQuery
{
    private readonly PublicHolidayDbContext _context;

    public PublicHolidayQuery(PublicHolidayDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PublicHoliday>> GetAllAsync()
    {
        return await _context.PublicHolidays
            .FromSqlRaw("SELECT * FROM PublicHolidays")
            .ToListAsync();
    }

    public async Task<IEnumerable<PublicHoliday>> GetByYearAsync(int year)
    {
        return await _context.PublicHolidays
            .FromSqlRaw("SELECT * FROM PublicHolidays WHERE YEAR(Date) = {0}", year)
            .ToListAsync();
    }

    public async Task<PublicHoliday?> GetByIdAsync(int id)
    {
        // Admin queries should use LINQ
        return await _context.PublicHolidays
            .Where(h => h.Id == id)
            .FirstOrDefaultAsync();
    }
}
