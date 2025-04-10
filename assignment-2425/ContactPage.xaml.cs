using Microsoft.Maui.Controls;
using System;

namespace assignment_2425;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Placeholder logic
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string message = MessageEditor.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
        {
            await DisplayAlert("Missing Info", "Please fill out all fields.", "OK");
            return;
        }

        if (message.Length > 500)
        {
            await DisplayAlert("Too Long", "Message must be 500 characters or fewer.", "OK");
            return;
        }

        await DisplayAlert("Thank You", "Your message has been submitted.", "OK");

        // Reset form
        NameEntry.Text = "";
        EmailEntry.Text = "";
        MessageEditor.Text = "";
    }

    private void OnMapTapped(object sender, EventArgs e)
    {
        string url = "https://www.google.com/maps/place/6+Chatsworth+Rd,+London+E5+0LP";
        Launcher.OpenAsync(new Uri(url));
    }
}
