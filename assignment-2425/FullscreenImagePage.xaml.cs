namespace assignment_2425;

[QueryProperty(nameof(ImageSource), "ImageSource")]
public partial class FullscreenImagePage : ContentPage
{
    public FullscreenImagePage()
    {
        InitializeComponent();
    }

    private ImageSource _imageSource;
    public ImageSource ImageSource
    {
        get => _imageSource;
        set
        {
            _imageSource = value;
            FullImage.Source = value;
        }
    }

    private async void CloseImage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}