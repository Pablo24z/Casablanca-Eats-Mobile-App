using System.Collections.ObjectModel;

namespace assignment_2425;

public partial class MenuPage : ContentPage
{
    public ObservableCollection<MenuImage> MenuImages { get; set; }
    public MenuPage()
    {
        InitializeComponent();

        MenuImages = new ObservableCollection<MenuImage>
        {
            new MenuImage { ImageSource = "menus/casablanca_menufront.png" },
            new MenuImage { ImageSource = "menus/casablanca_menuback.png" }
        };

        BindingContext = this;

    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        if (sender is Image image && image.Source != null)
        {
            string imagePath = (image.Source as FileImageSource)?.File;

            if (!string.IsNullOrEmpty(imagePath))
            {
                await Shell.Current.GoToAsync("///FullscreenImagePage", new Dictionary<string, object>
            {
                { "ImageSource", imagePath }
            });
            }
        }
    }
}

    public class MenuImage
{
    public string ImageSource { get; set; }
}