namespace VendingMachine.Tests
{
    public class ValidCoinTestData : TheoryData<Coin>
    {
        public ValidCoinTestData()
        {
            Add(Money.GBP.Denomination.FivePence);
            Add(Money.GBP.Denomination.TenPence);
            Add(Money.GBP.Denomination.TwentyPence);
            Add(Money.GBP.Denomination.FiftyPence);
            Add(Money.GBP.Denomination.OnePound);
            Add(Money.GBP.Denomination.TwoPounds);
        }
    }
}
