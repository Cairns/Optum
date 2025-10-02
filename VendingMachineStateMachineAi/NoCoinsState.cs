namespace VendingMachineStateMachineAi
{
    public class NoCoinsState : VendingMachineState
    {
        public NoCoinsState(VendingMachine machine) : base(machine) { }

        public override string Display => "INSERT COIN";

        public override VendingMachineState InsertCoin(Coin coin)
        {
            return new HasCoinsState(Machine);
        }

        public override VendingMachineState SelectProduct(Product product)
        {
            return new DisplayPriceState(Machine, product);
        }

        public override (VendingMachineState NextState, IEnumerable<Coin> Change) ReturnChange()
        {
            return (this, Array.Empty<Coin>());
        }
    }
}
