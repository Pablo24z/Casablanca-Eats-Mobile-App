using Microsoft.Maui.Controls;

namespace assignment_2425
{
    public partial class OrderConfirmationPage : ContentPage
    {
        public OrderConfirmationPage()
        {
            InitializeComponent();
        }

        // Navigate back to the OrderPage or any page you want
        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//OrderPage");
        }
    }
}
