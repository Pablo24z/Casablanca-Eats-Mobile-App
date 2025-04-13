using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace assignment_2425
{
    public class CheckoutViewModel : INotifyPropertyChanged
    {
        private string name, phone, street, city, postcode;
        private string cardName, cardNumber, cvv, expiry;

        public string Name { get => name; set => SetProperty(ref name, value); }
        public string Phone { get => phone; set => SetProperty(ref phone, value); }
        public string Street { get => street; set => SetProperty(ref street, value); }
        public string City { get => city; set => SetProperty(ref city, value); }
        public string Postcode { get => postcode; set => SetProperty(ref postcode, value); }

        public string CardName { get => cardName; set => SetProperty(ref cardName, value); }
        public string CardNumber { get => cardNumber; set => SetProperty(ref cardNumber, value); }
        public string CVV { get => cvv; set => SetProperty(ref cvv, value); }
        public string Expiry { get => expiry; set => SetProperty(ref expiry, value); }

        // Individual error messages
        public string NameError { get; set; }
        public string PhoneError { get; set; }
        public string CardError { get; set; }
        public string CVVError { get; set; }
        public string ExpiryError { get; set; }

        public bool ValidateForm()
        {
            bool isValid = true;

            NameError = string.IsNullOrWhiteSpace(Name) ? "Full name is required." : "";
            PhoneError = string.IsNullOrWhiteSpace(Phone) ? "Phone number is required." : "";

            CardError = string.IsNullOrWhiteSpace(CardNumber)
                ? "Card number is required."
                : (!Regex.IsMatch(CardNumber, @"^\d{12}$") ? "Card number must be 12 digits." : "");

            CVVError = string.IsNullOrWhiteSpace(CVV)
                ? "CVV is required."
                : (!Regex.IsMatch(CVV, @"^\d{3,4}$") ? "CVV must be 3 or 4 digits." : "");

            //REPLACE this whole block with the one below
            if (string.IsNullOrWhiteSpace(Expiry))
            {
                ExpiryError = "Expiry date is required.";
                isValid = false;
            }
            else if (!Regex.IsMatch(Expiry, @"^\d{2}/\d{2}$"))
            {
                ExpiryError = "Expiry must be in MM/YY format.";
                isValid = false;
            }
            else
            {
                try
                {
                    var parts = Expiry.Split('/');
                    int month = int.Parse(parts[0]);
                    int year = int.Parse(parts[1]) + 2000;

                    if (month < 1 || month > 12)
                    {
                        ExpiryError = "Invalid month in expiry date.";
                        isValid = false;
                    }
                    else
                    {
                        var expiryDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
                        if (expiryDate < DateTime.Today.AddMonths(1))
                        {
                            ExpiryError = "Card must be valid for at least 1 more month.";
                            isValid = false;
                        }
                        else
                        {
                            ExpiryError = "";
                        }
                    }
                }
                catch
                {
                    ExpiryError = "Invalid expiry format.";
                    isValid = false;
                }
            }

            if (!string.IsNullOrEmpty(NameError) || !string.IsNullOrEmpty(PhoneError)
                || !string.IsNullOrEmpty(CardError) || !string.IsNullOrEmpty(CVVError)
                || !string.IsNullOrEmpty(ExpiryError))
            {
                isValid = false;
            }

            OnPropertyChanged(nameof(NameError));
            OnPropertyChanged(nameof(PhoneError));
            OnPropertyChanged(nameof(CardError));
            OnPropertyChanged(nameof(CVVError));
            OnPropertyChanged(nameof(ExpiryError));

            return isValid;
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

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
