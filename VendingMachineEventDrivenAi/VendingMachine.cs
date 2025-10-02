using VendingMachineEventDriven.Models;
using VendingMachineEventDriven.Events;

namespace VendingMachineEventDriven
{
    public class VendingMachine
    {
        private readonly Dictionary<string, Product> _products;
        private decimal _currentBalance;
        private string _display;

        public event EventHandler<CoinInsertedEventArgs>? CoinInserted;
        public event EventHandler<ProductSelectedEventArgs>? ProductSelected;
        public event EventHandler<ChangeReturnedEventArgs>? ChangeReturned;

        public string Display
        {
            get
            {
                var currentDisplay = _display;
                UpdateDisplayAfterRead();
                return currentDisplay;
            }
            private set => _display = value;
        }

        public VendingMachine()
        {
            _products = new Dictionary<string, Product>
            {
                { "Cola", new Product("Cola", 1.00m) },
                { "Crisps", new Product("Crisps", 0.50m) },
                { "Chocolate", new Product("Chocolate", 0.65m) }
            };

            Display = "INSERT COIN";
        }

        public void InsertCoin(decimal value)
        {
            var coin = new Coin(value);

            if (!coin.IsValid)
            {
                ReturnCoins(new[] { coin });
                return;
            }

            _currentBalance += coin.Value;
            Display = FormatAmount(_currentBalance);
            CoinInserted?.Invoke(this, new CoinInsertedEventArgs(coin, _currentBalance));
        }

        public void SelectProduct(string productName)
        {
            if (!_products.TryGetValue(productName, out var product))
            {
                Display = "INVALID PRODUCT";
                return;
            }

            if (_currentBalance < product.Price)
            {
                Display = $"PRICE {FormatAmount(product.Price)}";
                return;
            }

            ProductSelected?.Invoke(this, new ProductSelectedEventArgs(product));

            var change = _currentBalance - product.Price;
            if (change > 0)
            {
                var changeCoins = CalculateChange(change);
                ReturnCoins(changeCoins);
            }

            _currentBalance = 0;
            Display = "THANK YOU";
        }

        private void ReturnCoins(IReadOnlyList<Coin> coins)
        {
            var amount = coins.Sum(c => c.Value);
            ChangeReturned?.Invoke(this, new ChangeReturnedEventArgs(amount, coins));
        }

        private void UpdateDisplayAfterRead()
        {
            if (_display == "THANK YOU")
            {
                Display = _currentBalance > 0 ? FormatAmount(_currentBalance) : "INSERT COIN";
            }
        }

        private static string FormatAmount(decimal amount) => $"£{amount:N2}";

        private static IReadOnlyList<Coin> CalculateChange(decimal amount)
        {
            var coins = new List<Coin>();
            var remainingAmount = amount;

            foreach (var coinValue in Coin.ValidValues.OrderByDescending(v => v))
            {
                while (remainingAmount >= coinValue)
                {
                    coins.Add(new Coin(coinValue));
                    remainingAmount -= coinValue;
                }
            }

            return coins;
        }
    }
}
