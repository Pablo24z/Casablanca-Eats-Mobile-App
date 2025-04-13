using assignment_2425.Models;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            // Watch for changes in the basket and update button state accordingly
            BasketManager.Instance.BasketItems.CollectionChanged += BasketItems_CollectionChanged;
            UpdateBasketButton();
        }

        // Navigates to the first item in the selected category
        private void ScrollToCategory(string category)
        {
            var item = viewModel.Dishes.FirstOrDefault(d => d.Category == category);
            if (item != null)
            {
                DishList.ScrollTo(item, position: ScrollToPosition.Start, animate: true);
            }
        }

        // Individual tab button handlers
        private void ScrollToMeals(object sender, EventArgs e) => ScrollToCategory("Meals");
        private void ScrollToPortions(object sender, EventArgs e) => ScrollToCategory("Portions");
        private void ScrollToSnacks(object sender, EventArgs e) => ScrollToCategory("Snacks");
        private void ScrollToSoups(object sender, EventArgs e) => ScrollToCategory("Soups");
        private void ScrollToDrinks(object sender, EventArgs e) => ScrollToCategory("Drinks");

        // Store press start time for long-press detection
        private void OnDishPressed(object sender, EventArgs e)
        {
            _pressStartTime = DateTime.UtcNow;
        }

        // Handles short vs long press logic
        private async void OnDishReleased(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is DishItem dish)
            {
                var pressDuration = DateTime.UtcNow - _pressStartTime;

                if (pressDuration.TotalMilliseconds >= 400)
                {
                    // Long press: Add item to basket with haptic feedback
                    HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
                    BasketManager.Instance.AddToBasket(dish);
                    await Toast.Make($"{dish.Name} added to basket").Show();
                }
                else
                {
                    // Short press: Navigate to dish detail page
                    HapticFeedback.Default.Perform(HapticFeedbackType.Click);
                    await Shell.Current.GoToAsync($"///{nameof(DishDetailPage)}", true, new Dictionary<string, object>
                    {
                        { "Dish", dish }
                    });
                }
            }
        }

        // Update basket button visibility & value on change
        private void BasketItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(UpdateBasketButton);
        }

        // Show/hide the basket button and update total cost
        private void UpdateBasketButton()
        {
            if (BasketManager.Instance.BasketItems.Any())
            {
                BasketButton.IsVisible = true;

                var total = BasketManager.Instance.BasketItems.Sum(item =>
                    item.Dish.Price * item.Quantity);

                BasketButton.Text = $"£{total:0.00}";
            }
            else
            {
                BasketButton.IsVisible = false;
            }
        }

        // Navigate to the basket view
        private async void OnBasketClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(BasketPage));
        }
    }
}
