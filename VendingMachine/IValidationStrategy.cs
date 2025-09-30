namespace VendingMachine
{
    public interface IValidationStrategy
    {
        public Currency ValidFor { get; }

        public bool IsValid(Coin coin);
    }
}
