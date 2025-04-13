using System.Collections.ObjectModel;

namespace assignment_2425
{
    public partial class MenuPage : ContentPage
    {
        // Bindable image collection used in the carousel
        public ObservableCollection<MenuImage> MenuImages { get; set; }

        public MenuPage()
        {
            InitializeComponent();

            // Set up the menu images for the carousel
            MenuImages = new ObservableCollection<MenuImage>
            {
                new MenuImage { ImageSource = "menus/casablanca_menufront.png" },
                new MenuImage { ImageSource = "menus/casablanca_menuback.png" }
            };

            BindingContext = this;
        }

        // When user taps on the image in the carousel, show it fullscreen
        private async void OnImageTapped(object sender, EventArgs e)
        {
            if (sender is Image image && image.Source != null)
            {
                // Get image file name
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

    // Represents a single menu image for the carousel
    public class MenuImage
    {
        public string ImageSource { get; set; }
    }
}
