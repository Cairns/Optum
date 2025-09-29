namespace VendingMachine
{
    /// <summary>
    /// Represents a coin with a specific currency and value.
    /// </summary>
    /// <remarks>This type is immutable. Once created, the currency and value of the coin cannot be
    /// changed.</remarks>
    public record Coin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class with the specified currency and value.
        /// </summary>
        /// <param name="currency">The currency associated with the coin. This parameter cannot be <see langword="null"/>.</param>
        /// <param name="value">The monetary value of the coin. Must be a non-negative integer.</param>
        public Coin(Currency currency, int value)
        {
            Currency = currency;
            Value = value;
        }

        /// <summary>
        /// Gets the currency associated with this coin.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Gets the monetary value of this coin.
        /// </summary>
        public int Value { get; }
    }
}