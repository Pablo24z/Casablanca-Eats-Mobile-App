using System;

namespace assignment_2425.Models
{
    // Represents an individual menu item/dish available for order
    public class DishItem
    {
        // Name of the dish (e.g., "BBQ Wings")
        public string Name { get; set; }

        // Description of the dish shown in detail page
        public string Description { get; set; }

        // Local image file or path used to visually represent the dish
        public string Image { get; set; }

        // Raw price value of the dish
        public decimal Price { get; set; }

        // Category this dish belongs to (e.g., Meals, Snacks)
        public string Category { get; set; }

        // Formatted price string shown on the UI
        public string DisplayPrice => "£" + Price.ToString("0.00");
    }
}
