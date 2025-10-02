namespace VendingMachineEventDriven.Models
{
    public record Coin(decimal Value)
    {
        public static readonly Coin OnePound = new(1.00m);
        public static readonly Coin TwoPound = new(2.00m);
        public static readonly Coin FiftyPence = new(0.50m);
        public static readonly Coin TwentyPence = new(0.20m);
        public static readonly Coin TenPence = new(0.10m);
        public static readonly Coin FivePence = new(0.05m);

        public static readonly IReadOnlySet<decimal> ValidValues = new HashSet<decimal>
        {
            0.05m, 0.10m, 0.20m, 0.50m, 1.00m, 2.00m
        };

        public bool IsValid => ValidValues.Contains(Value);
    }
}
