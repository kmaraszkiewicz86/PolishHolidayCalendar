using Microsoft.EntityFrameworkCore;
using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Infrastructure.Data;

public class PublicHolidayDbContext : DbContext
{
    public PublicHolidayDbContext(DbContextOptions<PublicHolidayDbContext> options) : base(options)
    {
    }

    public DbSet<PublicHoliday> PublicHolidays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PublicHoliday>(entity =>
        {
            entity.ToTable("PublicHolidays");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.LocalName).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.CountryCode).HasMaxLength(10);
        });
    }
}
