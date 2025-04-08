using Microsoft.Maui.Controls;

namespace assignment_2425;

public partial class StickyNavBar : ContentView
{
    private bool _isDarkMode = false;
    private bool _isFlyoutVisible = false;

    public StickyNavBar()
    {
        InitializeComponent();
    }

    private async void OnLogoTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MenuPage");
        ToggleFlyout(false);
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
        ToggleFlyout(false);
    }

    private async void OnOrderClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OrderPage");
        ToggleFlyout(false);
    }

    private void OnHamburgerClicked(object sender, EventArgs e)
    {
        _isFlyoutVisible = !_isFlyoutVisible;
        FlyoutMenu.IsVisible = _isFlyoutVisible;
    }

    private void ToggleFlyout(bool visible)
    {
        _isFlyoutVisible = visible;
        FlyoutMenu.IsVisible = visible;
    }

    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        _isDarkMode = !_isDarkMode;
        App.Current.UserAppTheme = _isDarkMode ? AppTheme.Dark : AppTheme.Light;

        ThemeToggleButton.Source = _isDarkMode ? "sun_icon.svg" : "moon_icon.svg";
    }
}
