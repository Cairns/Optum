namespace VendingMachine.Tests
{
    public class CoinTestData : TheoryData<Coin>
    {
        public CoinTestData()
        {
            Add(Money.GBP.Coinage.OnePence);
            Add(Money.GBP.Coinage.TwoPence);
            Add(Money.GBP.Coinage.FivePence);
            Add(Money.GBP.Coinage.TenPence);
            Add(Money.GBP.Coinage.TwentyPence);
            Add(Money.GBP.Coinage.FiftyPence);
            Add(Money.GBP.Coinage.OnePound);
            Add(Money.GBP.Coinage.TwoPounds);
        }
    }
}
