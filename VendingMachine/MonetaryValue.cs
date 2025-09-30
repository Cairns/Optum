namespace VendingMachine
{
    /// <summary>
    /// Represents a monetary value in a specific currency, typically expressed in the smallest unit of the currency
    /// (e.g., pence for GBP, cents for USD).
    /// </summary>
    /// <remarks>This type is immutable and provides a structured way to represent monetary values, ensuring
    /// that the value is always associated with a specific currency. It is commonly used in financial applications to
    /// handle amounts in a currency-safe manner.</remarks>
    public record MonetaryValue : IMonetaryValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonetaryValue"/> class with the specified currency and value.
        /// </summary>
        /// <param name="currency">The currency associated with the monetary value. This cannot be null.</param>
        /// <param name="value">The monetary value represented as an integer, typically in the smallest unit of the specified currency
        /// (e.g., pence for GBP).</param>
        public MonetaryValue(Currency currency, int value)
        {
            Currency = currency;
            Value = value;
        }

        /// <inheritdoc/>
        public Currency Currency { get; private set; }

        /// <inheritdoc/>
        public int Value { get; private set; }
    }
}
