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

        public async Task NavigateToDetailPage(DishItem dish)
        {
            await Shell.Current.GoToAsync(nameof(DishDetailPage), true, new Dictionary<string, object>
            {
                { "Dish", dish }
            });
        }

        public async Task AddToBasketWithFeedback(DishItem dish)
        {
            HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
            BasketManager.Instance.AddToBasket(dish);
            await Toast.Make($"{dish.Name} added to basket").Show();
        }
    }
}
