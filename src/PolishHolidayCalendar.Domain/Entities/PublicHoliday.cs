namespace PolishHolidayCalendar.Domain.Entities;

public class PublicHoliday
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string LocalName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public bool Fixed { get; set; }
    public bool Global { get; set; }
    public string[]? Counties { get; set; }
    public int? LaunchYear { get; set; }
    public string[]? Types { get; set; }
}
