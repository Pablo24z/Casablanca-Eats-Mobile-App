using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425.Models
{
    public class BasketItem
    {
        public DishItem Dish { get; set; }
        public int Quantity { get; set; }

        public string Name => Dish.Name;
        public decimal Price => Dish.Price;
        public string DisplayPrice => $"£{Dish.Price * Quantity:0.00}";
    }
}

