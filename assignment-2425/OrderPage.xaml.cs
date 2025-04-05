using assignment_2425.Models;

namespace assignment_2425;

public partial class OrderPage : ContentPage
{
    private OrderViewModel viewModel;

    public OrderPage()
    {
        InitializeComponent();
        viewModel = new OrderViewModel();
        BindingContext = viewModel;
    }

    private void ScrollToCategory(string category)
    {
        var item = viewModel.Dishes.FirstOrDefault(d => d.Category == category);
        if (item != null)
        {
            DishList.ScrollTo(item, position: ScrollToPosition.Start, animate: true);
        }
    }

    private void ScrollToMeals(object sender, EventArgs e) => ScrollToCategory("Meals");
    private void ScrollToPortions(object sender, EventArgs e) => ScrollToCategory("Portions");
    private void ScrollToSnacks(object sender, EventArgs e) => ScrollToCategory("Snacks");
    private void ScrollToSoups(object sender, EventArgs e) => ScrollToCategory("Soups");
    private void ScrollToDrinks(object sender, EventArgs e) => ScrollToCategory("Drinks");

    private async void OnDishTapped(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is DishItem dish)
        {
            await Shell.Current.GoToAsync(nameof(DishDetailPage), true, new Dictionary<string, object>
            {
                { "Dish", dish }
            });
        }
    }
}
