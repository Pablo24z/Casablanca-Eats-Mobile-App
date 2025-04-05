using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425
{
    public class DishItem
    {
        public string Name { get; set; }
        public string Description { get; set; }  // Optional for detail screen
        public string Image { get; set; }        // Optional for thumbnails
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
