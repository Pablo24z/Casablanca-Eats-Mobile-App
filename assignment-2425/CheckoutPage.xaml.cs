// This is the proposed structure for CheckoutPage.xaml.cs with GPS autofill, validation, and notification
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices.Sensors;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Devices;

namespace assignment_2425
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

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
                        StreetEntry.Text = placemark.Thoroughfare;
                        CityEntry.Text = placemark.Locality;
                        PostcodeEntry.Text = placemark.PostalCode;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Unable to get location: " + ex.Message, "OK");
            }
        }

        private async void OnSubmitOrderClicked(object sender, EventArgs e)
        {
            // Basic form validation
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(PhoneEntry.Text) ||
                string.IsNullOrWhiteSpace(CardNameEntry.Text) ||
                string.IsNullOrWhiteSpace(CardNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(CVVEntry.Text) ||
                string.IsNullOrWhiteSpace(ExpiryEntry.Text))
            {
                await DisplayAlert("Missing Info", "Please complete all required fields.", "OK");
                return;
            }

            if (!Regex.IsMatch(CardNumberEntry.Text, "^\-?[0-9]{16}$") ||
                !Regex.IsMatch(CVVEntry.Text, "^[0-9]{3}$"))
            {
                await DisplayAlert("Invalid Card Info", "Please check your card number and CVV.", "OK");
                return;
            }

            // Simulate Order Number
            var rand = new Random();
            var orderNumber = $"#{rand.Next(1000, 9999)}";

            // Toast & Vibrate
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(300));
            await Toast.Make($"Order {orderNumber} placed! ETA 25-40 min").Show();

            // Navigate to confirmation page
            await Shell.Current.GoToAsync($"OrderConfirmationPage?orderNumber={orderNumber}");
        }
    }
}
