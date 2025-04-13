using assignment_2425.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace assignment_2425
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BasketItem> _basketItems = new();
        public ObservableCollection<BasketItem> BasketItems
        {
            get => _basketItems;
            set
            {
                _basketItems = value;
                OnPropertyChanged(nameof(BasketItems));
            }
        }

        public decimal TotalCost => BasketItems.Sum(item => item.TotalPrice);

        public BasketViewModel()
        {
            LoadItemsFromBasket();
        }

        public void LoadItemsFromBasket()
        {
            var grouped = BasketManager.Instance.BasketItems
                .GroupBy(item => item.Dish.Name)
                .Select(group => new BasketItem
                {
                    Dish = group.First().Dish,
                    Quantity = group.Sum(x => x.Quantity)
                });

            BasketItems = new ObservableCollection<BasketItem>(grouped);
            OnPropertyChanged(nameof(TotalCost));
        }

        public void RemoveItem(BasketItem item)
        {
            var match = BasketManager.Instance.BasketItems
                .FirstOrDefault(d => d.Dish.Name == item.Dish.Name);

            if (match != null)
                BasketManager.Instance.BasketItems.Remove(match);

            LoadItemsFromBasket();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
