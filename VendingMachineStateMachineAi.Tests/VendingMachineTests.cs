namespace VendingMachineStateMachineAi.Tests
{
    public class VendingMachineTests
    {
        private readonly VendingMachine _machine;

        public VendingMachineTests()
        {
            _machine = new VendingMachine();
        }

        [Fact]
        public void Initial_State_Displays_InsertCoin()
        {
            Assert.Equal("INSERT COIN", _machine.Display);
        }

        [Theory]
        [InlineData(Coin.OnePence)]
        [InlineData(Coin.TwoPence)]
        public void Invalid_Coins_Are_Rejected(Coin coin)
        {
            _machine.InsertCoin(coin);
            Assert.Contains(coin, _machine.CoinReturn);
        }

        [Theory]
        [InlineData(Coin.FivePence, 5)]
        [InlineData(Coin.OnePound, 100)]
        public void Valid_Coins_Update_Display(Coin coin, int expectedAmount)
        {
            _machine.InsertCoin(coin);
            Assert.Equal($"£{expectedAmount / 100.0:F2}", _machine.Display);
        }

        [Fact]
        public void Selecting_Product_With_Insufficient_Funds_Shows_Price()
        {
            _machine.InsertCoin(Coin.FiftyPence);
            _machine.SelectProduct("Cola");
            Assert.Equal("PRICE £1.00", _machine.Display);
        }

        [Fact]
        public void Successful_Purchase_Shows_ThankYou()
        {
            _machine.InsertCoin(Coin.OnePound);
            _machine.SelectProduct("Cola");
            Assert.Equal("THANK YOU", _machine.Display);
        }

        [Fact]
        public void Correct_Change_Is_Returned()
        {
            _machine.InsertCoin(Coin.OnePound);
            _machine.SelectProduct("Crisps"); // 50p
            _machine.ReturnChange();

            var expectedChange = new[] { Coin.FiftyPence };
            Assert.Equal(expectedChange, _machine.CoinReturn);
        }
    }
}
