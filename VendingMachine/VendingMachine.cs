namespace VendingMachine
{
    public class VendingMachine(Currency currency,
        IValidationStrategy validationStrategy)
    {

        /// <summary>
        /// Gets the accepted currency associated with the current operation or context.
        /// </summary>
        public Currency Currency { get; private set; } = currency;

        /// <summary>
        /// Gets the current amount associated with the instance.
        /// </summary>
        public int CurrentAmount { get; private set; }

        /// <summary>
        /// Gets the validation strategy used to validate input data or objects.
        /// </summary>
        public IValidationStrategy ValidationStrategy { get; private set; } = validationStrategy;

        /// <summary>
        /// Displays the current amount in the machine or a prompt to insert a coin.
        /// </summary>
        /// <returns>A string representing the current amount formatted as currency if greater than zero;  otherwise, the string
        /// "INSERT COIN".</returns>
        public string Display()
        {
            if (CurrentAmount > 0)
            {
                return $"{Currency.Symbol}{CurrentAmount / 100.0:F2}";
            }
            return "INSERT COIN";
        }

        /// <summary>
        /// Adds the value of the specified coin to the current amount.
        /// </summary>
        /// <param name="coin">The coin to insert. Must not be null and must have a valid value.</param>
        public void InsertCoin(Coin coin)
        {
            if (!ValidationStrategy.IsValid(coin))
            {
                return;
            }
            CurrentAmount += coin.Value;
        }
    }
}
