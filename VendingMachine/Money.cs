namespace VendingMachine
{
    public class Money
    {
        public static class GBP
        {
            public static class Denomination
            {
                public static readonly Coin OnePence = new(Currency.GBP, 1);
                public static readonly Coin TwoPence = new(Currency.GBP, 2);
                public static readonly Coin FivePence = new(Currency.GBP, 5);
                public static readonly Coin TenPence = new(Currency.GBP, 10);
                public static readonly Coin TwentyPence = new(Currency.GBP, 20);
                public static readonly Coin FiftyPence = new(Currency.GBP, 50);
                public static readonly Coin OnePound = new(Currency.GBP, 100);
                public static readonly Coin TwoPounds = new(Currency.GBP, 200);
            }
        }
    }
}
