using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace assignment_2425.Models
{
    public class DishItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string DisplayPrice => "£" + Price.ToString("0.00");
    }

    public class OrderViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DishItem> Dishes { get; set; }

        public OrderViewModel()
        {
            Dishes = new ObservableCollection<DishItem>
            {
                new DishItem { Name = "Mini Chicken Meal", Category = "Meals", Price = 7.00m, Description = "Small portion of marinated chicken served with sides." },
                new DishItem { Name = "Mixed Chicken Meal", Category = "Meals", Price = 11.00m, Description = "A mix of our favourite chicken styles with sides." },
                new DishItem { Name = "Small Chicken/Fish Meal", Category = "Meals", Price = 9.00m, Description = "Small portion of chicken or fish with your choice of sides." },
                new DishItem { Name = "Large Chicken/Fish Meal", Category = "Meals", Price = 11.00m, Description = "Large portion of chicken or fish with sides." },
                new DishItem { Name = "Small Red Meat Meal", Category = "Meals", Price = 10.00m, Description = "Small serving of traditional red meat with rice and sides." },
                new DishItem { Name = "Large Red Meat Meal", Category = "Meals", Price = 12.00m, Description = "Hearty red meat portion served with your favourite sides." },
                new DishItem { Name = "Small Red Bream Meal", Category = "Meals", Price = 10.00m, Description = "Grilled red bream fish served in a smaller portion." },
                new DishItem { Name = "Large Red Bream Meal", Category = "Meals", Price = 12.00m, Description = "Generous portion of fresh red bream with sides." },
                new DishItem { Name = "Mixed Meat Meal", Category = "Meals", Price = 12.00m, Description = "Selection of meats with traditional island seasonings." },
                new DishItem { Name = "Steamed Fish Meal", Category = "Meals", Price = 15.00m, Description = "Whole fish steamed with vegetables and spices." },
                new DishItem { Name = "Curry Chicken", Category = "Portions", Price = 7.00m, Description = "Spiced curry chicken slow-cooked to perfection." },
                new DishItem { Name = "Fried Chicken", Category = "Portions", Price = 6.00m, Description = "Crispy golden fried chicken packed with flavour." },
                new DishItem { Name = "Jerk Chicken", Category = "Portions", Price = 7.00m, Description = "Spicy, marinated grilled chicken." },
                new DishItem { Name = "Stew Chicken", Category = "Portions", Price = 7.00m, Description = "Tender chicken in a rich brown stew sauce." },
                new DishItem { Name = "BBQ Wings", Category = "Portions", Price = 4.00m, Description = "Sweet and tangy barbecued wings." },
                new DishItem { Name = "Fried Wings", Category = "Portions", Price = 4.00m, Description = "Crispy, deep-fried chicken wings." },
                new DishItem { Name = "Ackee & Saltfish", Category = "Portions", Price = 6.00m, Description = "Jamaica's national dish, savoury ackee with salted cod." },
                new DishItem { Name = "Butter Bean & Saltfish", Category = "Portions", Price = 6.00m, Description = "Creamy butter beans and salted fish." },
                new DishItem { Name = "Callaloo & Saltfish", Category = "Portions", Price = 6.00m, Description = "Leafy callaloo sautéed with salted fish." },
                new DishItem { Name = "Okra & Saltfish", Category = "Portions", Price = 6.00m, Description = "Fresh okra with spiced salted cod." },
                new DishItem { Name = "Fried Fish", Category = "Portions", Price = 7.00m, Description = "Crispy, golden-fried fish fillet." },
                new DishItem { Name = "Prawns", Category = "Portions", Price = 6.00m, Description = "Juicy seasoned prawns, pan-fried or grilled." },
                new DishItem { Name = "Red Sea Bream", Category = "Portions", Price = 3.50m, Description = "Tender sea bream fillet with herbs." },
                new DishItem { Name = "Salted Mackerel", Category = "Portions", Price = 6.00m, Description = "Traditional island-style salted mackerel." },
                new DishItem { Name = "Sea Bass", Category = "Portions", Price = 7.00m, Description = "Delicate sea bass seasoned and grilled." },
                new DishItem { Name = "Cow Foot", Category = "Portions", Price = 8.00m, Description = "Slow-braised cow foot in rich gravy." },
                new DishItem { Name = "Curry Goat", Category = "Portions", Price = 8.00m, Description = "Spiced, tender goat meat in curry sauce." },
                new DishItem { Name = "Oxtail", Category = "Portions", Price = 8.00m, Description = "Rich, slow-cooked oxtail in gravy." },
                new DishItem { Name = "Pepper Steak", Category = "Portions", Price = 8.00m, Description = "Spicy stir-fried steak with peppers." },
                new DishItem { Name = "Stew Peas", Category = "Portions", Price = 8.00m, Description = "Pigeon peas cooked in a rich, coconut broth." },
                new DishItem { Name = "Fried Rice", Category = "Portions", Price = 5.00m, Description = "Fluffy rice stir-fried with seasoning." },
                new DishItem { Name = "Rice & Peas", Category = "Portions", Price = 4.00m, Description = "Classic Caribbean rice with kidney beans." },
                new DishItem { Name = "Hard Food", Category = "Portions", Price = 1.00m, Description = "Traditional boiled provisions like yam and dumpling." },
                new DishItem { Name = "White Rice", Category = "Portions", Price = 4.00m, Description = "Steamed white rice, plain and simple." },
                new DishItem { Name = "Curry Chick Pea Meal", Category = "Meals", Price = 9.00m, Description = "Hearty chickpeas in curry sauce with rice." },
                new DishItem { Name = "Steam Veg Meal", Category = "Meals", Price = 9.00m, Description = "Steamed seasonal vegetables served with rice." },
                new DishItem { Name = "Cornmeal", Category = "Portions", Price = 4.00m, Description = "Warm, spiced cornmeal porridge." },
                new DishItem { Name = "Peanut", Category = "Portions", Price = 4.00m, Description = "Creamy peanut porridge." },
                new DishItem { Name = "Oats", Category = "Portions", Price = 4.00m, Description = "Classic oats porridge with spice." },
                new DishItem { Name = "Banana", Category = "Portions", Price = 4.00m, Description = "Rich banana porridge, great for mornings." },
                new DishItem { Name = "Beef Soup", Category = "Soups", Price = 4.50m, Description = "Beef broth soup with dumplings and veggies." },
                new DishItem { Name = "Chicken Soup", Category = "Soups", Price = 4.50m, Description = "Traditional chicken soup with hearty fixings." },
                new DishItem { Name = "Chicken Foot Soup", Category = "Soups", Price = 4.50m, Description = "Island-style soup featuring chicken feet." },
                new DishItem { Name = "Cow Foot Soup", Category = "Soups", Price = 4.50m, Description = "Slow-cooked cow foot with dumplings in broth." },
                new DishItem { Name = "Goat Soup", Category = "Soups", Price = 4.50m, Description = "Savory goat broth soup with vegetables." },
                new DishItem { Name = "Red Pea Soup", Category = "Soups", Price = 4.50m, Description = "Pea soup rich with coconut milk and spices." },
                new DishItem { Name = "Coleslaw", Category = "Snacks", Price = 2.00m, Description = "Creamy shredded coleslaw with a tangy finish." },
                new DishItem { Name = "Curry Chick Pea", Category = "Snacks", Price = 5.00m, Description = "Spicy chickpeas cooked in curry seasoning." },
                new DishItem { Name = "Festivals", Category = "Snacks", Price = 1.00m, Description = "Sweet fried dumplings, perfect as a side." },
                new DishItem { Name = "Fried Dumplings", Category = "Snacks", Price = 0.75m, Description = "Golden brown crispy dumplings." },
                new DishItem { Name = "Mac & Cheese", Category = "Snacks", Price = 3.50m, Description = "Cheesy baked macaroni with a golden crust." },
                new DishItem { Name = "Patties", Category = "Snacks", Price = 2.50m, Description = "Flaky pastry filled with seasoned meat or veg." },
                new DishItem { Name = "Plantain", Category = "Snacks", Price = 2.00m, Description = "Sweet fried plantain slices." },
                new DishItem { Name = "Salad", Category = "Snacks", Price = 1.00m, Description = "Fresh mixed green salad." },
                new DishItem { Name = "Sprats", Category = "Snacks", Price = 5.00m, Description = "Crispy whole fried sprats." },
                new DishItem { Name = "Steam Veg", Category = "Snacks", Price = 4.00m, Description = "Steamed medley of vegetables." },
                new DishItem { Name = "Soda Can (Any)", Category = "Drinks", Price = 1.00m, Description = "Your choice of canned soda." },
                new DishItem { Name = "Beetroot Juice", Category = "Drinks", Price = 5.00m, Description = "Fresh beetroot juice, earthy and nutritious." },
                new DishItem { Name = "Carrot Juice", Category = "Drinks", Price = 5.00m, Description = "Sweet and healthy carrot juice." },
                new DishItem { Name = "Cucumber Juice", Category = "Drinks", Price = 5.00m, Description = "Refreshing cucumber blend." },
                new DishItem { Name = "Fruit Punch", Category = "Drinks", Price = 5.00m, Description = "Tropical fruit blend juice." },
                new DishItem { Name = "Guiness Punch", Category = "Drinks", Price = 5.00m, Description = "Stout-based creamy punch." },
                new DishItem { Name = "Kool Aid", Category = "Drinks", Price = 3.00m, Description = "Classic sweet flavoured drink." },
                new DishItem { Name = "Water", Category = "Drinks", Price = 1.00m, Description = "Bottled water." },
                new DishItem { Name = "Magnum Juice", Category = "Drinks", Price = 5.00m, Description = "Tonic wine-based beverage." },
                new DishItem { Name = "Pumpkin Juice", Category = "Drinks", Price = 5.00m, Description = "Sweetened pumpkin drink." },
                new DishItem { Name = "Sea Moss", Category = "Drinks", Price = 5.00m, Description = "Nutrient-rich sea moss blend." },
                new DishItem { Name = "Sour Sop Juice", Category = "Drinks", Price = 6.00m, Description = "Exotic sour sop fruit drink." },
                new DishItem { Name = "Sorrel", Category = "Drinks", Price = 5.00m, Description = "Hibiscus flower drink with spices." }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
