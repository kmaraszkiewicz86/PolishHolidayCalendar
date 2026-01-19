using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Infrastructure.Data;

namespace PolishHolidayCalendar.Infrastructure.Repositories;

public class PublicHolidayRepository : IPublicHolidayRepository
{
    private readonly PublicHolidayDbContext _context;

    public PublicHolidayRepository(PublicHolidayDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(IEnumerable<PublicHoliday> holidays)
    {
        foreach (var holiday in holidays)
        {
            var existingHoliday = await _context.PublicHolidays
                .FirstOrDefaultAsync(h => h.Date == holiday.Date && h.CountryCode == holiday.CountryCode);

            if (existingHoliday == null)
            {
                _context.PublicHolidays.Add(holiday);
            }
            else
            {
                existingHoliday.LocalName = holiday.LocalName;
                existingHoliday.Name = holiday.Name;
                existingHoliday.Fixed = holiday.Fixed;
                existingHoliday.Global = holiday.Global;
                existingHoliday.Counties = holiday.Counties;
                existingHoliday.LaunchYear = holiday.LaunchYear;
                existingHoliday.Types = holiday.Types;
                _context.PublicHolidays.Update(existingHoliday);
            }
        }

        await _context.SaveChangesAsync();
    }
}
