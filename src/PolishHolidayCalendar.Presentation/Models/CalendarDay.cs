namespace PolishHolidayCalendar.Presentation.Models
{
    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public bool IsCurrentMonth { get; set; }
        public bool IsHoliday { get; set; }
    }

}
