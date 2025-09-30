namespace VendingMachine.Tests
{
    public class InvalidCoinTestData : TheoryData<Coin>
    {
        public InvalidCoinTestData()
        {
            Add(Money.GBP.Denomination.OnePence);
            Add(Money.GBP.Denomination.TwoPence);
        }
    }
}
