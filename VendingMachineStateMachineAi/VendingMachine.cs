namespace VendingMachineStateMachineAi
{
    public class VendingMachine
    {
        private VendingMachineState _currentState;
        private readonly List<Product> _products;
        public IReadOnlyList<Coin> CoinReturn { get; private set; } = new List<Coin>();
        public int CurrentAmount { get; set; }

        public VendingMachine()
        {
            _products = new List<Product>
        {
            new Product("Cola", 100),    // £1.00
            new Product("Crisps", 50),   // 50p
            new Product("Chocolate", 65)  // 65p
        };
            _currentState = new NoCoinsState(this);
        }

        public string Display => _currentState.Display;

        public void InsertCoin(Coin coin)
        {
            if (IsValidCoin(coin))
            {
                CurrentAmount += (int)coin;
                _currentState = _currentState.InsertCoin(coin);
            }
            else
            {
                CoinReturn = new List<Coin> { coin };
            }
        }

        public void SelectProduct(string productName)
        {
            var product = _products.FirstOrDefault(p => p.Name == productName);
            if (product != null)
            {
                _currentState = _currentState.SelectProduct(product);
            }
        }

        public void ReturnChange()
        {
            var (nextState, change) = _currentState.ReturnChange();
            _currentState = nextState;
            CoinReturn = change.ToList();
            CurrentAmount = 0;
        }

        private bool IsValidCoin(Coin coin) =>
            coin != Coin.OnePence && coin != Coin.TwoPence;
    }
}
