using Microsoft.Maui.Controls;

namespace assignment_2425;

public partial class StickyNavBar : ContentView
{
    private bool isDarkMode = false;

    public StickyNavBar()
    {
        InitializeComponent();
        SizeChanged += StickyNavBar_SizeChanged;
    }

    private void StickyNavBar_SizeChanged(object sender, EventArgs e)
    {
        double width = Width;
        bool isPhone = width < 600;

        NavButtonsPanel.IsVisible = !isPhone;
        HamburgerButton.IsVisible = isPhone;

        // Delay hiding flyout to avoid glitch
        Device.BeginInvokeOnMainThread(() =>
        {
            if (!isPhone)
                FlyoutMenu.IsVisible = false;
        });
    }

    private async void OnLogoTapped(object sender, EventArgs e)
    {
        Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
        await Shell.Current.GoToAsync("//MenuPage");
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
        await Shell.Current.GoToAsync("//ContactPage");
    }

    private async void OnOrderClicked(object sender, EventArgs e)
    {
        Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
        await Shell.Current.GoToAsync("//OrderPage");
    }

    private void OnHamburgerClicked(object sender, EventArgs e)
    {
        FlyoutMenu.IsVisible = !FlyoutMenu.IsVisible;
    }

    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        isDarkMode = !isDarkMode;
        App.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;
        ThemeToggleButton.Source = isDarkMode ? "sun_icon.svg" : "moon_icon.svg";
    }
}
