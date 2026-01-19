using PolishHolidayCalendar.Presentation.ViewModels;

namespace PolishHolidayCalendar.Presentation.Views;

public partial class CalendarStartPage : ContentPage
{
	public CalendarStartPage(CalendarStartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}