using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolishHolidayCalendar.Domain.Entities;

namespace PolishHolidayCalendar.Infrastructure.Database.Configurations;

public class PublicHolidayConfiguration : IEntityTypeConfiguration<PublicHoliday>
{
    public void Configure(EntityTypeBuilder<PublicHoliday> builder)
    {
        builder.ToTable("PublicHolidays");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.LocalName).HasMaxLength(200);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.CountryCode).HasMaxLength(10);
    }
}
