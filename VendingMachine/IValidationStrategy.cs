namespace VendingMachine
{
    public interface IValidationStrategy
    {
        /// <summary>
        /// Gets the currency for which this instance is valid.
        /// </summary>
        public Currency ValidFor { get; }

        /// <summary>
        /// Gets the collection of valid coins for the specified currency.
        /// </summary>
        public IReadOnlyCollection<Coin> ValidCoins { get; }

        /// <summary>
        /// Determines whether the specified coin is valid.
        /// </summary>
        /// <param name="coin">The coin to validate. Must not be <see langword="null"/>.</param>
        /// <returns><see langword="true"/> if the specified coin is valid; otherwise, <see langword="false"/>.</returns>
        public bool IsValid(Coin coin);
    }
}
