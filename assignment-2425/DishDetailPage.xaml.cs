using assignment_2425.Models;

namespace assignment_2425;

[QueryProperty(nameof(Dish), "Dish")]
public partial class DishDetailPage : ContentPage
{
    private DishItem _dish;
    public DishItem Dish
    {
        get => _dish;
        set
        {
            _dish = value;
            BindingContext = _dish; // Automatically bind the view to the dish details
        }
    }

    public DishDetailPage()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Go back to the previous page
    }
}