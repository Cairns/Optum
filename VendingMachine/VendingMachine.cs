namespace VendingMachine
{
    public class VendingMachine
    {
        public int CurrentAmount { get; private set; }

        public VendingMachine() { }

        public static string Display()
        {
            return "INSERT COIN";
        }

        public void InsertCoin(Coin coin)
        {
            //TODO: Validate coin
            CurrentAmount += coin.Value;
        }
    }
}
