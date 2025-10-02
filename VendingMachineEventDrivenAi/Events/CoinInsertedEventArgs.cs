using VendingMachineEventDriven.Models;

namespace VendingMachineEventDriven.Events
{
    public class CoinInsertedEventArgs : EventArgs
    {
        public Coin Coin { get; }
        public decimal CurrentBalance { get; }

        public CoinInsertedEventArgs(Coin coin, decimal currentBalance)
        {
            Coin = coin;
            CurrentBalance = currentBalance;
        }
    }
}
