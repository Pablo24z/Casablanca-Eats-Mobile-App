using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment_2425.Models;

namespace assignment_2425;

public class BasketManager
{
    private static BasketManager _instance;
    public static BasketManager Instance => _instance ??= new BasketManager();

    public ObservableCollection<DishItem> BasketItems { get; private set; } = new();

    private BasketManager() { }

    public void AddToBasket(DishItem item)
    {
        BasketItems.Add(item);
    }

    public void RemoveLastItem()
    {
        if (BasketItems.Any())
            BasketItems.RemoveAt(BasketItems.Count - 1);
    }

    public void ClearBasket()
    {
        BasketItems.Clear();
    }
}

