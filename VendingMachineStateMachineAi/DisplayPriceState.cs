namespace VendingMachineStateMachineAi
{
    public class DisplayPriceState : VendingMachineState
    {
        private readonly Product _product;

        public DisplayPriceState(VendingMachine machine, Product product) : base(machine)
        {
            _product = product;
        }

        public override string Display => $"PRICE £{_product.PriceInPence / 100.0:F2}";

        public override VendingMachineState InsertCoin(Coin coin)
        {
            return new HasCoinsState(Machine);
        }

        public override VendingMachineState SelectProduct(Product product)
        {
            return this;
        }

        public override (VendingMachineState NextState, IEnumerable<Coin> Change) ReturnChange()
        {
            var change = Machine.CurrentAmount > 0
                ? new[] { (Coin)Machine.CurrentAmount }
                : Array.Empty<Coin>();
            return (new NoCoinsState(Machine), change);
        }
    }
}
