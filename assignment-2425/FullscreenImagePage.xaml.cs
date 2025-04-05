namespace assignment_2425;

[QueryProperty(nameof(ImageSource), "ImageSource")]
public partial class FullscreenImagePage : ContentPage
{
    public string ImageSource
    {
        set => FullImage.Source = value;
    }

    public FullscreenImagePage()
    {
        InitializeComponent();
    }

    private async void CloseImage(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during navigation
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
