using System.Text.RegularExpressions;

namespace assignment_2425;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }

    private void OnPrivacyCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        SubmitButton.IsEnabled = e.Value;
        SubmitButton.Opacity = e.Value ? 1 : 0.5;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        bool hasError = false;

        // Reset background colors first
        EmailEntry.BackgroundColor = Color.FromArgb("#1C1C1C");
        MessageEditor.BackgroundColor = Color.FromArgb("#1C1C1C");

        // Email validation
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !Regex.IsMatch(EmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            EmailEntry.BackgroundColor = Colors.DarkRed;
            hasError = true;
        }

        // Message validation
        if (string.IsNullOrWhiteSpace(MessageEditor.Text))
        {
            MessageEditor.BackgroundColor = Colors.DarkRed;
            hasError = true;
        }

        if (hasError)
        {
            await DisplayAlert("Error", "Please complete all required fields correctly.", "OK");
            return;
        }

        await DisplayAlert("Thank You", "Your message has been submitted.", "OK");

        // Reset
        NameEntry.Text = "";
        EmailEntry.Text = "";
        MessageEditor.Text = "";
        PrivacyCheckBox.IsChecked = false;
    }
}
