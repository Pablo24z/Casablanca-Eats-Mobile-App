using Microsoft.Maui.Controls;

namespace assignment_2425;

public partial class StickyNavBar : ContentView
{
	public StickyNavBar()
	{
		InitializeComponent();
	}
	private async void OnLogoTapped(object sender, EventArgs e)
    {
        // Handle the event
        await Shell.Current.GoToAsync("//MainPage");
    }
	private async void OnMenuClicked(object sender, EventArgs e)
    {
        // Handle the event
        await Shell.Current.GoToAsync("//MenuPage");
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        // Handle the event
        await Shell.Current.GoToAsync("//ContactPage");
    }

	private async void OnOrderClicked(object sender, EventArgs e)
    {
		// Handle the event
		await Shell.Current.GoToAsync("//OrderPage");
    }


}