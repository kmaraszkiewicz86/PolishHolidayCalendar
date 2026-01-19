using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Infrastructure.Database;

namespace PolishHolidayCalendar.Infrastructure.Repositories;

public class PublicHolidayRepository : IPublicHolidayRepository
{
    private readonly PublicHolidayDbContext _context;

    public PublicHolidayRepository(PublicHolidayDbContext context)
    {
        _context = context;
    }

    public void Save(IEnumerable<PublicHoliday> holidays)
    {
        var holidayList = holidays.ToList();
        
        // Fetch all existing holidays for the given dates and country codes in one query
        var dates = holidayList.Select(h => h.Date).ToList();
        var countryCodes = holidayList.Select(h => h.CountryCode).Distinct().ToList();
        
        var existingHolidays = _context.PublicHolidays
            .Where(h => dates.Contains(h.Date) && countryCodes.Contains(h.CountryCode))
            .ToList();
        
        var existingHolidaysDict = existingHolidays
            .ToDictionary(h => (h.Date, h.CountryCode));

        foreach (var holiday in holidayList)
        {
            var key = (holiday.Date, holiday.CountryCode);
            
            if (!existingHolidaysDict.TryGetValue(key, out var existingHoliday))
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
    }
}
