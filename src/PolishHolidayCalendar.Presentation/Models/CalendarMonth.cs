namespace PolishHolidayCalendar.Presentation.Models
{
    public class CalendarMonth
    {
        public string MonthTitle { get; set; } = string.Empty;
        public List<CalendarDay> Days { get; set; } = [];
    }

}
