namespace VendingMachine.Tests
{
    public class ProductTestData : TheoryData<Product>
    {
        public ProductTestData()
        {
            Add(new Product("Cola", new MonetaryValue(Currency.GBP, 100)));
            Add(new Product("Crisps", new MonetaryValue(Currency.GBP, 50)));
            Add(new Product("Chocolate", new MonetaryValue(Currency.GBP, 65)));
        }
    }
}
