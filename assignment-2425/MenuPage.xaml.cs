using System.Collections.ObjectModel;

namespace assignment_2425;

public partial class MenuPage : ContentPage
{
	public ObservableCollection<string> MenuImages { get; set; }
	public MenuPage()
	{
		InitializeComponent();

		MenuImages = new ObservableCollection<string>
		{
			"menus/casablanca_menufront.png",
			"menus/casablanca_menuback.png"
		};

		BindingContext = this;

	}

	private async void OnImageTapped(object sender, EventArgs e)
	{
		if (sender is Image image && image.Source != null)
		{
			await Shell.Current.GoToAsync("FullscreenImagePage", true, new Dictionary<string, object>
			{
				{
					"ImageSource", image.Source
				}
			});
		}
	}
}