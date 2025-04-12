using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment_2425.Models;

namespace assignment_2425;

public static class BasketManager
{
    public static ObservableCollection<DishItem> Basket { get; private set; } = new();

    public static void AddToBasket(DishItem dish)
    {
        Basket.Add(dish);
    }

    public static void RemoveLastItem()
    {
        if (Basket.Any())
            Basket.RemoveAt(Basket.Count - 1);
    }

    public static void ClearBasket()
    {
        Basket.Clear();
    }
}
