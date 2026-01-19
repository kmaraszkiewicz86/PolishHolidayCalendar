using CommunityToolkit.Mvvm.ComponentModel;
using PolishHolidayCalendar.Presentation.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PolishHolidayCalendar.Presentation.ViewModels
{
    public class CalendarStartViewModel : ObservableObject
    {
        public ObservableCollection<CalendarMonth> Months { get; } = new();

        public CalendarStartViewModel()
        {
            SomeTextProperty = "Hello, World!";

            var start = DateTime.Today.AddMonths(-6);

            for (int i = 0; i < 12; i++)
                Months.Add(BuildMonth(start.AddMonths(i)));
        }

        public string SomeTextProperty
        {
            get => field;
            set => SetProperty(ref field, value);
        } = string.Empty;

        public ICommand LoadCommand => new CommunityToolkit.Mvvm.Input.AsyncRelayCommand(LoadAsync);

        private async Task LoadAsync()
        {
            await Task.Delay(2000); // Simulate a long-running task

            SomeTextProperty = "Data loaded!";
        }

        private static CalendarMonth BuildMonth(DateTime month)
        {
            var firstDayOfMonth = new DateTime(month.Year, month.Month, 1);

            // Poniedziałek = 0, Wt = 1, ..., Niedziela = 6
            int offset = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            var startDate = firstDayOfMonth.AddDays(-offset);

            var days = new List<CalendarDay>();

            for (int i = 0; i < 42; i++) // 7 × 6
            {
                var date = startDate.AddDays(i);

                days.Add(new CalendarDay
                {
                    Date = date,
                    IsCurrentMonth = date.Month == month.Month,
                    IsHoliday = false // do uzupełnienia z API
                });
            }

            return new CalendarMonth
            {
                MonthTitle = firstDayOfMonth.ToString("MMMM yyyy"),
                Days = days
            };
        }



    }
}
