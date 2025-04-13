using Microsoft.Maui.Controls;

namespace assignment_2425
{
    public partial class StickyNavBar : ContentView
    {
        private bool isDarkMode = false;

        public StickyNavBar()
        {
            InitializeComponent();
            SizeChanged += StickyNavBar_SizeChanged;
        }

        // Adjust layout visibility based on screen width (responsive logic)
        private void StickyNavBar_SizeChanged(object sender, EventArgs e)
        {
            double width = Width;
            bool isPhone = width < 600;

            NavButtonsPanel.IsVisible = !isPhone;
            HamburgerButton.IsVisible = isPhone;

            // Small delay avoids glitch when switching to desktop layout
            Device.BeginInvokeOnMainThread(() =>
            {
                if (!isPhone)
                    FlyoutMenu.IsVisible = false;
            });
        }

        // Logo tapped - navigate to home page
        private async void OnLogoTapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
            await Shell.Current.GoToAsync("//MainPage");
        }

        // Nav to Menu page
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
            await Shell.Current.GoToAsync("//MenuPage");
        }

        // Nav to Contact page
        private async void OnContactClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
            await Shell.Current.GoToAsync("//ContactPage");
        }

        // Nav to Order page
        private async void OnOrderClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => FlyoutMenu.IsVisible = false);
            await Shell.Current.GoToAsync("//OrderPage");
        }

        // Toggles flyout menu on mobile when hamburger is clicked
        private void OnHamburgerClicked(object sender, EventArgs e)
        {
            FlyoutMenu.IsVisible = !FlyoutMenu.IsVisible;
        }

        // Toggle app theme between light and dark
        private void OnToggleThemeClicked(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            App.Current.UserAppTheme = isDarkMode ? AppTheme.Dark : AppTheme.Light;
            ThemeToggleButton.Source = isDarkMode ? "sun_icon.svg" : "moon_icon.svg";
        }
    }
}
