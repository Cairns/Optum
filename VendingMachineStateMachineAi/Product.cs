namespace VendingMachineStateMachineAi
{
    public class Product
    {
        public string Name { get; }
        public int PriceInPence { get; }

        public Product(string name, int priceInPence)
        {
            Name = name;
            PriceInPence = priceInPence;
        }
    }
}
