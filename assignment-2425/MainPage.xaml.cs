using Android.Locations;

namespace assignment_2425
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }

        private async void OnOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderPage());
        }

        private async void OnContactClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }
    }

}
