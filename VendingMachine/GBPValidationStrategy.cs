namespace VendingMachine
{
    /// <summary>
    /// Provides a validation strategy for coins specific to the British Pound (GBP) currency.
    /// </summary>
    /// <remarks>This strategy validates whether a given coin is a valid denomination for GBP currency. It
    /// defines the set of valid coins and ensures that the coin's currency matches GBP.</remarks>
    public class GBPValidationStrategy : IValidationStrategy
    {
        /// <inheritdoc />
        public Currency ValidFor => Currency.GBP;

        /// <inheritdoc />
        public IReadOnlyCollection<Coin> ValidCoins => new List<Coin>
        {
            Money.GBP.Denomination.FivePence,
            Money.GBP.Denomination.TenPence,
            Money.GBP.Denomination.TwentyPence,
            Money.GBP.Denomination.FiftyPence,
            Money.GBP.Denomination.OnePound,
            Money.GBP.Denomination.TwoPounds
        };

        /// <inheritdoc />
        public bool IsValid(Coin coin)
        {
            if (coin.Currency != ValidFor)
            {
                return false;
            }

            if (!ValidCoins.Contains(coin))
            {
                return false;
            }

            return true;
        }
    }
}
