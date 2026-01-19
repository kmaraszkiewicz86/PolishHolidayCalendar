using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Infrastructure.Database;

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
            .FromSqlInterpolated($"SELECT * FROM PublicHolidays")
            .ToListAsync();
    }

    public async Task<IEnumerable<PublicHoliday>> GetByYearAsync(int year)
    {
        return await _context.PublicHolidays
            .FromSqlInterpolated($"SELECT * FROM PublicHolidays WHERE YEAR(Date) = {year}")
            .ToListAsync();
    }

    public async Task<PublicHoliday?> GetByIdAsync(int id)
    {
        return await _context.PublicHolidays
            .FromSqlInterpolated($"SELECT * FROM PublicHolidays WHERE Id = {id}")
            .FirstOrDefaultAsync();
    }
}
