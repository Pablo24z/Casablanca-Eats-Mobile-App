using System.Text.RegularExpressions;

namespace assignment_2425;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();

        // Live error-clearing as user types
        EmailEntry.TextChanged += (s, e) => HideEmailError();
        MessageEditor.TextChanged += (s, e) => HideMessageError();
    }

    // Toggle button enable state based on Privacy checkbox
    private void OnPrivacyCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        SubmitButton.IsEnabled = e.Value;
        SubmitButton.Opacity = e.Value ? 1 : 0.5;
    }

    // Validate & submit form on button click
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        bool hasError = false;

        // Reset colors and hide all errors
        EmailEntry.BackgroundColor = Color.FromArgb("#1C1C1C");
        MessageEditor.BackgroundColor = Color.FromArgb("#1C1C1C");
        EmailErrorLabel.IsVisible = false;
        MessageErrorLabel.IsVisible = false;

        // EMAIL VALIDATION
        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            EmailEntry.BackgroundColor = Colors.DarkRed;
            EmailErrorLabel.Text = "Email is required.";
            EmailErrorLabel.IsVisible = true;
            hasError = true;
        }
        else if (!Regex.IsMatch(EmailEntry.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            EmailEntry.BackgroundColor = Colors.DarkRed;
            EmailErrorLabel.Text = "Email must be valid (contain '@' and a domain).";
            EmailErrorLabel.IsVisible = true;
            hasError = true;
        }

        // MESSAGE VALIDATION
        if (string.IsNullOrWhiteSpace(MessageEditor.Text))
        {
            MessageEditor.BackgroundColor = Colors.DarkRed;
            MessageErrorLabel.Text = "Message is required.";
            MessageErrorLabel.IsVisible = true;
            hasError = true;
        }

        // If validation failed, show alert and return
        if (hasError)
        {
            await DisplayAlert("Error", "Please fix the highlighted errors.", "OK");
            return;
        }

        // Success confirmation
        await DisplayAlert("Thank You", "Your message has been submitted.", "OK");

        // Reset form after submission
        NameEntry.Text = "";
        EmailEntry.Text = "";
        MessageEditor.Text = "";
        PrivacyCheckBox.IsChecked = false;
    }

    // Hide email error when user begins correcting it
    private void HideEmailError()
    {
        EmailErrorLabel.IsVisible = false;
        EmailEntry.BackgroundColor = Color.FromArgb("#1C1C1C");
    }

    // Hide message error when user begins correcting it
    private void HideMessageError()
    {
        MessageErrorLabel.IsVisible = false;
        MessageEditor.BackgroundColor = Color.FromArgb("#1C1C1C");
    }
}
