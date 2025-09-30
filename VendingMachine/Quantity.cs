namespace VendingMachine
{
    /// <summary>
    /// Represents a non-negative quantity value.
    /// </summary>
    /// <remarks>The <see cref="Quantity"/> type is immutable and ensures that the quantity value is always
    /// non-negative. Instances of this type can be used to represent counts, measurements, or other quantities where
    /// negative values are not allowed.</remarks>
    public record Quantity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quantity"/> class with the specified amount.
        /// </summary>
        /// <param name="amount">The non-negative quantity value to initialize the instance with.</param>
        public Quantity(uint amount)
        {
            Amount = amount;
        }

        /// <summary>
        /// Gets the amount associated with this <see cref="Quantity"/>.
        /// </summary>
        public uint Amount { get; }
    }
}
