namespace VendingMachine.Tests
{
    public class InvalidCoinTestData : TheoryData<Coin>
    {
        public InvalidCoinTestData()
        {
            Add(Money.GBP.Coinage.OnePence);
            Add(Money.GBP.Coinage.TwoPence);
        }
    }
}
