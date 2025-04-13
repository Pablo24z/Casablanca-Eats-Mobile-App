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

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is BasketItem item)
            {
                viewModel.RemoveItem(item);
                Toast.Make("Item has been removed from your order!").Show();
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(CheckoutPage));
        }

        private void SimulateShakeClicked(object sender, EventArgs e)
        {
            OnShakeDetected(this, EventArgs.Empty);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.ShakeDetected += OnShakeDetected;
                Accelerometer.Start(SensorSpeed.UI);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ShakeDetected -= OnShakeDetected;
                Accelerometer.Stop();
            }
        }

        private void OnShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Debug.WriteLine(" Shake detected!");

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
