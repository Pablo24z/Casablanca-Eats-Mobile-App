using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment_2425
{
    public partial class OrderPage : ContentPage
    {
        private OrderViewModel viewModel;
        private DateTime _pressStartTime;

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

        private void OnDishPressed(object sender, EventArgs e)
        {
            _pressStartTime = DateTime.UtcNow;
        }

        private async void OnDishReleased(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is DishItem dish)
            {
                var pressDuration = DateTime.UtcNow - _pressStartTime;

                if (pressDuration.TotalMilliseconds >= 600)
                {
                    // Long Press = Add to basket
                    HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
                    BasketManager.Instance.AddToBasket(dish);
                    await Toast.Make($"{dish.Name} added to basket").Show();
                }
                else
                {
                    // Short Press = Navigate to detail
                    HapticFeedback.Default.Perform(HapticFeedbackType.Click);
                    await Shell.Current.GoToAsync(nameof(DishDetailPage), true, new Dictionary<string, object>
                    {
                        { "Dish", dish }
                    });
                }
            }
        }
    }
}
