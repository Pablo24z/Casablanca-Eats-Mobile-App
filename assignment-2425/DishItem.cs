using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File: Models/DishItem.cs
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
}
