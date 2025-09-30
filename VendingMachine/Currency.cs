namespace VendingMachine
{
    /// <summary>
    /// Represents a currency with an ISO 4217 code and a symbol.
    /// </summary>
    /// <remarks>This type is immutable and is used to encapsulate information about a specific currency,
    /// including its standardized code and associated symbol.</remarks>
    public record Currency
    {
        /// <summary>
        /// ISO 4217 Currency Code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the symbol representing the financial instrument or asset.
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// Gets the symbol used to represent cents in currency formatting.
        /// </summary>
        public string CentSymbol { get; }

        public Currency(string code, string symbol, string centSymbol)
        {
            Code = code;
            Symbol = symbol;
            CentSymbol = centSymbol;
        }

        /// <summary>
        /// Represents the British Pound Sterling currency.
        /// </summary>
        /// <remarks>This static field provides a predefined instance of the <see cref="Currency"/> class
        /// for the British Pound Sterling, with the ISO 4217 code "GBP" and the symbol "£" and the cent symbol "p".</remarks>
        public static Currency GBP = new("GBP", "£", "p");
    }
}
