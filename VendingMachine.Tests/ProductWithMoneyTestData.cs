namespace VendingMachine.Tests
{
    public class ProductWithMoneyTestData : TheoryData<Product, Coin>
    {
        public ProductWithMoneyTestData()
        {
            Add(new Product("Cola", new MonetaryValue(Currency.GBP, 100)), Money.GBP.Denomination.FiftyPence);
            Add(new Product("Crisps", new MonetaryValue(Currency.GBP, 50)), Money.GBP.Denomination.TwentyPence);
            Add(new Product("Chocolate", new MonetaryValue(Currency.GBP, 65)), Money.GBP.Denomination.FiftyPence);
        }
    }
}

