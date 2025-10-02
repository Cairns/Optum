namespace VendingMachineStateMachineAi
{
    public abstract class VendingMachineState
    {
        protected readonly VendingMachine Machine;

        protected VendingMachineState(VendingMachine machine)
        {
            Machine = machine;
        }

        public abstract string Display { get; }
        public abstract VendingMachineState InsertCoin(Coin coin);
        public abstract VendingMachineState SelectProduct(Product product);
        public abstract (VendingMachineState NextState, IEnumerable<Coin> Change) ReturnChange();
    }
}
