using Microsoft.Extensions.DependencyInjection;
using PolishHolidayCalendar.Presentation.ViewModels;
using PolishHolidayCalendar.Presentation.Views;

namespace PolishHolidayCalendar.UI.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // ViewModels
            services.AddTransient<CalendarStartViewModel>();

            // Views
            services.AddTransient<CalendarStartPage>();

            return services;
        }
    }
}
