using assignment_2425.Models;
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using Microsoft.Maui.Devices.Sensors;
using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

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

        // Removes the tapped item from the basket
        private void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is BasketItem item)
            {
                viewModel.RemoveItem(item);
                Toast.Make("Item has been removed from your order!").Show();
            }
        }

        // Navigates to the checkout page
        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CheckoutPage));
        }

        // Manually simulates a shake gesture (for testing)
        private void SimulateShakeClicked(object sender, EventArgs e)
        {
            OnShakeDetected(this, EventArgs.Empty);
        }

        // Starts accelerometer monitoring when page appears
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.ShakeDetected += OnShakeDetected;
                Accelerometer.Start(SensorSpeed.UI);
            }
        }

        // Stops accelerometer monitoring when page disappears
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ShakeDetected -= OnShakeDetected;
                Accelerometer.Stop();
            }
        }

        // Triggered on shake gesture — removes last item from the basket
        private void OnShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Debug.WriteLine("Shake detected!");

                if (viewModel.BasketItems.Any())
                {
                    BasketManager.Instance.RemoveLastItem();
                    viewModel.LoadItemsFromBasket();
                    Toast.Make("Last item removed by shake!").Show();
                }
            });
        }
    }
}
