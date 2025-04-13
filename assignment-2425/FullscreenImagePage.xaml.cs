namespace assignment_2425;

// Allows parameter to be passed via routing (e.g., ?ImageSource=menus/image.png)
[QueryProperty(nameof(ImageSource), "ImageSource")]
public partial class FullscreenImagePage : ContentPage
{
    public FullscreenImagePage()
    {
        InitializeComponent();
    }

    // Bound property that sets the image shown on the fullscreen page
    public string ImageSource
    {
        set => FullImage.Source = value;
    }

    // Closes the fullscreen view and returns to the MenuPage
    private async void CloseImage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MenuPage");
    }
}
