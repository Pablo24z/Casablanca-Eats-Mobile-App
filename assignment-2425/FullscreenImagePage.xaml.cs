namespace assignment_2425;

[QueryProperty(nameof(ImageSource), "ImageSource")]
public partial class FullscreenImagePage : ContentPage
{
    public FullscreenImagePage()
    {
        InitializeComponent();
    }

    public string ImageSource
    {
        set => FullImage.Source = value;
    }

    private async void CloseImage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MenuPage");
    }
}
