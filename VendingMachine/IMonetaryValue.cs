namespace VendingMachine
{
    /// <summary>
    /// Represents a monetary value, including its amount and associated currency.
    /// </summary>
    /// <remarks>This interface is typically used to model financial values in a specific currency. 
    /// Implementations of this interface should ensure that the <see cref="Value"/> and  <see cref="Currency"/>
    /// properties are consistent and accurately represent the monetary value.</remarks>
    public interface IMonetaryValue
    {
        /// <summary>
        /// Gets the currency associated with this <see cref="IMonetaryValue"/>.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// The monetary value of this <see cref="IMonetaryValue"/> item in the smallest currency unit (e.g., cents).
        /// </summary>
        public int Value { get; }
    }
}
