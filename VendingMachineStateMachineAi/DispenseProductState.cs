namespace VendingMachineStateMachineAi
{
    public class DispenseProductState : VendingMachineState
    {
        public DispenseProductState(VendingMachine machine) : base(machine) { }

        public override string Display => "THANK YOU";

        public override VendingMachineState InsertCoin(Coin coin)
        {
            return new HasCoinsState(Machine);
        }

        public override VendingMachineState SelectProduct(Product product)
        {
            return new NoCoinsState(Machine);
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
