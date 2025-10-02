namespace VendingMachineStateMachineAi
{
    public class HasCoinsState : VendingMachineState
    {
        public HasCoinsState(VendingMachine machine) : base(machine) { }

        public override string Display => $"£{Machine.CurrentAmount / 100.0:F2}";

        public override VendingMachineState InsertCoin(Coin coin)
        {
            return this;
        }

        public override VendingMachineState SelectProduct(Product product)
        {
            if (Machine.CurrentAmount >= product.PriceInPence)
            {
                Machine.CurrentAmount -= product.PriceInPence;
                return new DispenseProductState(Machine);
            }
            return new DisplayPriceState(Machine, product);
        }

        public override (VendingMachineState NextState, IEnumerable<Coin> Change) ReturnChange()
        {
            var change = CalculateChange(Machine.CurrentAmount);
            return (new NoCoinsState(Machine), change);
        }

        private IEnumerable<Coin> CalculateChange(int amount)
        {
            var coins = new List<Coin>();
            var remainingAmount = amount;

            while (remainingAmount > 0)
            {
                if (remainingAmount >= (int)Coin.TwoPounds)
                {
                    coins.Add(Coin.TwoPounds);
                    remainingAmount -= (int)Coin.TwoPounds;
                }
                else if (remainingAmount >= (int)Coin.OnePound)
                {
                    coins.Add(Coin.OnePound);
                    remainingAmount -= (int)Coin.OnePound;
                }
                else if (remainingAmount >= (int)Coin.FiftyPence)
                {
                    coins.Add(Coin.FiftyPence);
                    remainingAmount -= (int)Coin.FiftyPence;
                }
                else if (remainingAmount >= (int)Coin.TwentyPence)
                {
                    coins.Add(Coin.TwentyPence);
                    remainingAmount -= (int)Coin.TwentyPence;
                }
                else if (remainingAmount >= (int)Coin.TenPence)
                {
                    coins.Add(Coin.TenPence);
                    remainingAmount -= (int)Coin.TenPence;
                }
                else
                {
                    coins.Add(Coin.FivePence);
                    remainingAmount -= (int)Coin.FivePence;
                }
            }
            return coins;
        }
    }
}
