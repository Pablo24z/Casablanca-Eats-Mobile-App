using Microsoft.Maui.Controls;

namespace assignment_2425
{
    public partial class OrderConfirmationPage : ContentPage
    {
        public OrderConfirmationPage()
        {
            InitializeComponent();
        }

        // This handles the button press to return the user to the main order page
        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            // Navigates back to the main ordering screen
            await Shell.Current.GoToAsync("//OrderPage");
        }
    }
}
