using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;
using PolishHolidayCalendar.Infrastructure.Database.Configurations;

namespace PolishHolidayCalendar.Infrastructure.Database;

public class PublicHolidayDbContext : DbContext
{
    public PublicHolidayDbContext(DbContextOptions<PublicHolidayDbContext> options) : base(options)
    {
    }

    public DbSet<PublicHoliday> PublicHolidays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PublicHolidayConfiguration());
    }
}
