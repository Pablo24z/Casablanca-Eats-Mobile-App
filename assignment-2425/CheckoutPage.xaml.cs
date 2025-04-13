using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Maui.Devices;

namespace assignment_2425
{
    public partial class CheckoutPage : ContentPage
    {
        private CheckoutViewModel viewModel;

        public CheckoutPage()
        {
            InitializeComponent();

            // Bind the ViewModel to the page
            viewModel = new CheckoutViewModel();
            BindingContext = viewModel;
        }

        // Handles order submission
        private async void OnPlaceOrderClicked(object sender, EventArgs e)
        {
            // Validate user input first
            if (!viewModel.ValidateForm())
                return;

            var orderNumber = $"#{new Random().Next(1000, 9999)}";
            var encodedOrderNumber = Uri.EscapeDataString(orderNumber);

            // Haptic + toast notification
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(300));
            await Toast.Make($"Order {orderNumber} placed! *Vibration* ETA 25–40 min").Show();

            // Navigate to confirmation screen
            await Shell.Current.GoToAsync($"OrderConfirmationPage?orderNumber={encodedOrderNumber}");
        }

        // Auto-format the Expiry field as MM/YY while typing
        private void ExpiryEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                var text = entry.Text?.Replace("/", "") ?? "";

                if (text.Length > 2)
                    text = text.Insert(2, "/");

                if (text.Length > 5)
                    text = text.Substring(0, 5);

                entry.Text = text;
            }
        }

        // Fetch user location via GPS and fill in address fields
        private async void OnGetLocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                }

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location);
                    var placemark = placemarks?.FirstOrDefault();

                    if (placemark != null)
                    {
                        // Autofill location details into the form
                        viewModel.Street = placemark.Thoroughfare;
                        viewModel.City = placemark.Locality;
                        viewModel.Postcode = placemark.PostalCode;
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Unable to get location: {ex.Message}", "OK");
            }
        }
    }
}
