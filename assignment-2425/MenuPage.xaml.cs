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
		if (sender is Image image && image.Source is FileImageSource fileSource)
		{
			await Shell.Current.GoToAsync("///FullscreenImagePage", new Dictionary<string, object>
			{
				{
					"ImageSource", fileSource.File
				}
			});
		}
	}

    //private void OnImageTapped(object sender, TappedEventArgs e)
    //{

    //}
}

public class MenuImage
{
    public string ImageSource { get; set; }
}