using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PolishHolidayCalendar.Application.Handlers.CommandHandlers;
using PolishHolidayCalendar.Domain.Queries;
using PolishHolidayCalendar.Domain.Repositories;
using PolishHolidayCalendar.Domain.Services;
using PolishHolidayCalendar.Infrastructure.Database;
using PolishHolidayCalendar.Infrastructure.HttpServices;
using PolishHolidayCalendar.Infrastructure.Queries;
using PolishHolidayCalendar.Infrastructure.Repositories;
using SimpleCqrs;

namespace PolishHolidayCalendar.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddPolishHolidayCalendarServices(
        this IServiceCollection services,
        string connectionString)
    {
        // Configure SimpleCqrs with handlers from Application layer
        services.ConfigureSimpleCqrs(typeof(SaveHolidaysCommandHandler).Assembly);

        // Register EF Core DbContext
        services.AddDbContext<PublicHolidayDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register Domain services
        services.AddScoped<PublicHolidayService>();

        // Register Infrastructure repositories
        services.AddScoped<IPublicHolidayRepository, PublicHolidayRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register Infrastructure queries
        services.AddScoped<IPublicHolidayQuery, PublicHolidayQuery>();

        // Register HTTP service
        services.AddHttpClient<IPolishHolidayHttpService, PolishHolidayHttpService>();

        return services;
    }
}
