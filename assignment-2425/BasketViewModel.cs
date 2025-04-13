using assignment_2425.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace assignment_2425
{
    public class BasketViewModel : INotifyPropertyChanged
    {
        // Backing field for the observable basket item list
        private ObservableCollection<BasketItem> _basketItems = new();

        // Public property bound to the UI
        public ObservableCollection<BasketItem> BasketItems
        {
            get => _basketItems;
            set
            {
                _basketItems = value;
                OnPropertyChanged(nameof(BasketItems)); // Notifies UI of change
            }
        }

        // Computes the total cost of all items in the basket
        public decimal TotalCost => BasketItems.Sum(item => item.TotalPrice);

        // Constructor loads items into the basket when ViewModel is created
        public BasketViewModel()
        {
            LoadItemsFromBasket();
        }

        // Groups basket items by dish and recalculates quantities
        public void LoadItemsFromBasket()
        {
            var grouped = BasketManager.Instance.BasketItems
                .GroupBy(item => item.Dish.Name)
                .Select(group => new BasketItem
                {
                    Dish = group.First().Dish,
                    Quantity = group.Sum(x => x.Quantity)
                });

            // Update the observable collection to trigger UI refresh
            BasketItems = new ObservableCollection<BasketItem>(grouped);

            // Notify the UI to update total cost display
            OnPropertyChanged(nameof(TotalCost));
        }

        // Removes one instance of a specific item from the basket
        public void RemoveItem(BasketItem item)
        {
            var match = BasketManager.Instance.BasketItems
                .FirstOrDefault(d => d.Dish.Name == item.Dish.Name);

            if (match != null)
                BasketManager.Instance.BasketItems.Remove(match);

            // Reload basket to reflect updated state
            LoadItemsFromBasket();
        }

        // Boilerplate INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
