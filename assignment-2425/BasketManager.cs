using assignment_2425.Models;
using System.Collections.ObjectModel;

// Represents an item added to the basket, including its quantity and total price
public class BasketItem
{
    public DishItem Dish { get; set; }
    public int Quantity { get; set; } = 1;

    // Automatically calculates total price for this item
    public decimal TotalPrice => Dish.Price * Quantity;
}

// Manages the user's basket — adding, removing, and tracking all items
public class BasketManager
{
    private static BasketManager _instance;

    // Singleton instance for easy global access
    public static BasketManager Instance => _instance ??= new BasketManager();

    // Collection bound to the UI so changes reflect live
    public ObservableCollection<BasketItem> BasketItems { get; private set; } = new();

    // Private constructor enforces singleton pattern
    private BasketManager() { }

    // Adds a dish to the basket — increases quantity if it already exists
    public void AddToBasket(DishItem item)
    {
        var existing = BasketItems.FirstOrDefault(x => x.Dish.Name == item.Name);

        if (existing != null)
            existing.Quantity++;
        else
            BasketItems.Add(new BasketItem { Dish = item });
    }

    // Removes one unit of the most recently added item
    public void RemoveLastItem()
    {
        if (BasketItems.Any())
        {
            var last = BasketItems.Last();

            if (last.Quantity > 1)
                last.Quantity--;
            else
                BasketItems.Remove(last);
        }
    }

    // Removes a specific item from the basket completely
    public void RemoveItem(BasketItem item)
    {
        if (BasketItems.Contains(item))
            BasketItems.Remove(item);
    }

    // Calculates the total cost of everything in the basket
    public decimal TotalCost => BasketItems.Sum(x => x.TotalPrice);
}
