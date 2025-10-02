using VendingMachineEventDriven.Models;

namespace VendingMachineEventDriven.Events
{
    public class ChangeReturnedEventArgs : EventArgs
    {
        public decimal Amount { get; }
        public IReadOnlyList<Coin> Coins { get; }

        public ChangeReturnedEventArgs(decimal amount, IReadOnlyList<Coin> coins)
        {
            Amount = amount;
            Coins = coins;
        }
    }
}
