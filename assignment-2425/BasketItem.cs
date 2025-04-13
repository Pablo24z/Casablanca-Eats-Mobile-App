using System;

namespace assignment_2425.Models
{
    /// Represents an item in the user's basket, including quantity and pricing logic.
    public class BasketItem
    {
        /// Actual dish being added to the basket.
        public DishItem Dish { get; set; }

        /// Quantity of the dish the user wants to order.
        public int Quantity { get; set; }

        /// Property to access the dish name directly.
        public string Name => Dish.Name;

        /// Price of a single unit of this dish.
        public decimal Price => Dish.Price;

        /// Total price for this basket item (price * quantity), formatted nicely for display.
        public string DisplayPrice => $"£{Dish.Price * Quantity:0.00}";
    }
}
