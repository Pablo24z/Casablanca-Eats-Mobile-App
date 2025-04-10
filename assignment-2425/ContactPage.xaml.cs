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
        bool hasError = false;

        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            NameEntry.BackgroundColor = Colors.DarkRed;
            hasError = true;
        }
        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            EmailEntry.BackgroundColor = Colors.DarkRed;
            hasError = true;
        }
        if (string.IsNullOrWhiteSpace(MessageEditor.Text))
        {
            MessageEditor.BackgroundColor = Colors.DarkRed;
            hasError = true;
        }

        if (hasError)
        {
            await DisplayAlert("Error", "Please complete all fields.", "OK");
            return;
        }

        if (MessageEditor.Text.Length > 500)
        {
            await DisplayAlert("Too Long", "Message must be 500 characters or fewer.", "OK");
            return;
        }

        await DisplayAlert("Thank You", "Your message has been submitted.", "OK");

        NameEntry.Text = "";
        EmailEntry.Text = "";
        MessageEditor.Text = "";

        NameEntry.BackgroundColor = Color.FromArgb("#1C1C1C");
        EmailEntry.BackgroundColor = Color.FromArgb("#1C1C1C");
        MessageEditor.BackgroundColor = Color.FromArgb("#1C1C1C");
    }
}
