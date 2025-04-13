using assignment_2425.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace assignment_2425
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BasketItem> BasketItems { get; set; } = new();

        public decimal TotalCost => BasketItems.Sum(item => item.Dish.Price * item.Quantity);

        public BasketViewModel()
        {
            LoadItemsFromBasket();
        }

        public void LoadItemsFromBasket()
        {
            BasketItems.Clear();

            var grouped = BasketManager.Instance.BasketItems
                .GroupBy(item => item.Dish.Name)
                .Select(group =>
                    new BasketItem
                    {
                        Dish = group.First().Dish,
                        Quantity = group.Sum(x => x.Quantity)
                    });


            foreach (var item in grouped)
            {
                BasketItems.Add(item);
            }

            OnPropertyChanged(nameof(TotalCost));
        }

        public void RemoveItem(BasketItem item)
        {
            // Remove one instance of the dish from BasketManager
            var match = BasketItems.FirstOrDefault(d => d.Dish.Name == item.Dish.Name);
            if (match != null)
                BasketManager.Instance.BasketItems.Remove(match);

            LoadItemsFromBasket();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
