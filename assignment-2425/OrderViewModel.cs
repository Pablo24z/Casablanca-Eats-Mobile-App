using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425.Models
{
    public class DishItem
    {
        public string Name { get; set; }
        public string Category { get; set; } // For section filtering
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } // Optional
    }

    public class OrderViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DishItem> Dishes { get; set; }

        public OrderViewModel()
        {
            Dishes = new ObservableCollection<DishItem>
            {
                new DishItem { Name = "Mini Chicken Meal", Category = "Meals", Price = "£7.00" },
                new DishItem { Name = "Large Chicken/Fish Meal", Category = "Meals", Price = "£11.00" },
                new DishItem { Name = "Curry Chicken", Category = "Portions", Price = "£7.00" },
                new DishItem { Name = "Stew Chicken", Category = "Portions", Price = "£7.00" },
                new DishItem { Name = "Coleslaw", Category = "Snacks", Price = "£2.00" },
                new DishItem { Name = "Prawns", Category = "Portions", Price = "£6.00" },
                new DishItem { Name = "Fruit Punch", Category = "Drinks", Price = "£5.00" },
                new DishItem { Name = "Goat Soup", Category = "Soups", Price = "£4.50" },
                // You can continue the full list here...
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
