using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace assignment_2425
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private string name, phone, street, city, postcode;
        private string cardName, cardNumber, cvv, expiry;
        private string errorMessage;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Phone { get => phone; set => SetProperty(ref phone, value); }
        public string Street { get => street; set => SetProperty(ref street, value); }
        public string City { get => city; set => SetProperty(ref city, value); }
        public string Postcode { get => postcode; set => SetProperty(ref postcode, value); }

        public string CardName { get => cardName; set => SetProperty(ref cardName, value); }
        public string CardNumber { get => cardNumber; set => SetProperty(ref cardNumber, value); }
        public string CVV { get => cvv; set => SetProperty(ref cvv, value); }
        public string Expiry { get => expiry; set => SetProperty(ref expiry, value); }

        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        public bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Phone) ||
                string.IsNullOrWhiteSpace(Street) || string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(Postcode) ||
                string.IsNullOrWhiteSpace(CardName) || string.IsNullOrWhiteSpace(CardNumber) ||
                string.IsNullOrWhiteSpace(CVV) || string.IsNullOrWhiteSpace(Expiry))
            {
                ErrorMessage = "Please fill in all fields.";
                return false;
            }

            if (!Regex.IsMatch(CardNumber, @"^\d{12}$"))
            {
                ErrorMessage = "Card number must be 12 digits.";
                return false;
            }

            if (!Regex.IsMatch(CVV, @"^\d{3,4}$"))
            {
                ErrorMessage = "CVV must be 3 or 4 digits.";
                return false;
            }

            if (!Regex.IsMatch(Expiry, @"^\d{2}/\d{2}$"))
            {
                ErrorMessage = "Expiry must be in MM/YY format.";
                return false;
            }

            ErrorMessage = "";
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
