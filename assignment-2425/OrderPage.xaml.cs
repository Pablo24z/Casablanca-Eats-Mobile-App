using assignment_2425.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using CommunityToolkit.Maui.Alerts;
using System.Threading.Tasks;

namespace assignment_2425;

public partial class OrderPage : ContentPage
{
    private OrderViewModel viewModel;

    public OrderPage()
    {
        InitializeComponent();
        viewModel = new OrderViewModel();
        BindingContext = viewModel;

        // Enable shake detection (we'll add this logic later when shake-to-remove is implemented)
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

    private async void OnDishLongPressed(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is DishItem dish)
        {
            BasketManager.Instance.AddToBasket(dish);
            HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            await Toast.Make($"{dish.Name} added to basket").Show();
        }
    }
}
