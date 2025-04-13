using assignment_2425.Models;
using System.Collections.ObjectModel;

public class BasketItem
{
    public DishItem Dish { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal TotalPrice => Dish.Price * Quantity;
}

public class BasketManager
{
    private static BasketManager _instance;
    public static BasketManager Instance => _instance ??= new BasketManager();

    public ObservableCollection<BasketItem> BasketItems { get; private set; } = new();

    private BasketManager() { }

    public void AddToBasket(DishItem item)
    {
        var existing = BasketItems.FirstOrDefault(x => x.Dish.Name == item.Name);
        if (existing != null)
            existing.Quantity++;
        else
            BasketItems.Add(new BasketItem { Dish = item });
    }

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

    public void RemoveItem(BasketItem item)
    {
        if (BasketItems.Contains(item))
            BasketItems.Remove(item);
    }

    public decimal TotalCost => BasketItems.Sum(x => x.TotalPrice);
}
