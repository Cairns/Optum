namespace VendingMachine.Tests
{
    public class ValidCoinTestData : TheoryData<Coin>
    {
        public ValidCoinTestData()
        {
            Add(Money.GBP.Coinage.FivePence);
            Add(Money.GBP.Coinage.TenPence);
            Add(Money.GBP.Coinage.TwentyPence);
            Add(Money.GBP.Coinage.FiftyPence);
            Add(Money.GBP.Coinage.OnePound);
            Add(Money.GBP.Coinage.TwoPounds);
        }
    }
}
