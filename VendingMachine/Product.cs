namespace VendingMachine
{
    public record Product : IMonetaryValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified name, currency, and value.
        /// </summary>
        /// <param name="name">The name of the product. Cannot be null or empty.</param>
        /// <param name="currency">The currency associated with the product's value. Cannot be null.</param>
        /// <param name="value">The value of the product in the specified currency. Must be a non-negative integer.</param>
        public Product(string name, Currency currency, int value)
        {
            Name = name;
            Currency = currency;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with the specified name and monetary value.
        /// </summary>
        /// <param name="name">The name of the product. Cannot be null or empty.</param>
        /// <param name="monetaryValue">An object representing the monetary value of the product, including its currency and value.  Cannot be null.</param>
        public Product(string name, IMonetaryValue monetaryValue)
            : this(name, monetaryValue.Currency, monetaryValue.Value)
        {
        }

        /// <summary>
        /// Gets the name associated with this product instance.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the currency associated with this product.
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// The monetary value of this product in the smallest currency unit (e.g., cents).
        /// </summary>
        public int Value { get; }
    }
}
