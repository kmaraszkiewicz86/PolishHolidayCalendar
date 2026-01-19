using Microsoft.Extensions.DependencyInjection;
using PolishHolidayCalendar.Domain.Interfaces;
using PolishHolidayCalendar.Infrastructure.HttpServices;

// Setup Dependency Injection
var serviceProvider = new ServiceCollection()
    .AddHttpClient<IHttpService, PolishHolidayHttpService>()
    .Services
    .BuildServiceProvider();

// Get the service and fetch holidays
var httpService = serviceProvider.GetRequiredService<IHttpService>();

Console.WriteLine("Fetching Polish public holidays for 2026...");
Console.WriteLine();

var holidays = await httpService.GetPublicHolidaysAsync(2026, "PL");

foreach (var holiday in holidays)
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} - {holiday.LocalName} ({holiday.Name})");
}

Console.WriteLine();
Console.WriteLine($"Total holidays fetched: {holidays.Count()}");
