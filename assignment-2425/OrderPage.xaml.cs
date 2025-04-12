using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment_2425;

public partial class OrderPage : ContentPage
{
    private OrderViewModel viewModel;

    private bool _isLongPressHandled = false;
    private DateTime _pressStart;
    private DishItem _currentPressedDish;

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
        if (_isLongPressHandled)
        {
            _isLongPressHandled = false;
            return; // Skip tap if it was part of a long press
        }

        if (sender is Grid grid && grid.BindingContext is DishItem dish)
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.Click);

            await Shell.Current.GoToAsync(nameof(DishDetailPage), true, new Dictionary<string, object>
            {
                { "Dish", dish }
            });
        }
    }

    // Called from OnPointerPressed in TouchEffect or future alternative
    public async Task HandleLongPress(DishItem dish)
    {
        _isLongPressHandled = true;
        HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        BasketManager.Instance.AddToBasket(dish);
        await Toast.Make($"{dish.Name} added to basket").Show();
    }
}
