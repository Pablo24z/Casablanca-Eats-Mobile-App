using assignment_2425.Models;
using System;
using Microsoft.Maui.Controls;

namespace assignment_2425
{
    public partial class BasketPage : ContentPage
    {
        private BasketViewModel viewModel;

        public BasketPage()
        {
            InitializeComponent();
            viewModel = new BasketViewModel();
            BindingContext = viewModel;
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is BasketItem item)
            {
                System.Diagnostics.Debug.WriteLine($"Removing item: {item.Dish.Name}");
                viewModel.RemoveItem(item); // This was missing!
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Checkout", "Proceeding to checkout!", "OK");
            // TODO: Add real checkout logic
        }

        private void TestClickHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Test button clicked!");
        }

    }
}
