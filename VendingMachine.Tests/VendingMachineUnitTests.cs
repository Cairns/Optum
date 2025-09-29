namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void Display_Should_Show_Insert_Coin_When_No_Coins_Are_Inserted()
        {
            // Arrange
            _ = new VendingMachine();

            // Act
            var displayMessage = VendingMachine.Display();

            // Assert
            Assert.Equal("INSERT COIN", displayMessage);
        }

        [Theory]
        [InlineData(Money.GBP.Coinage.OnePence)]
        public void Insert_Coin_Should_Update_Display_Message(Money.GBP.Coinage coin)
        {
            // Arrange
            var vendingMachine = new VendingMachine();
            // Act
            vendingMachine.InsertCoin(coin);
            var displayMessage = VendingMachine.Display();
            // Assert
            Assert.Equal("£0.01", displayMessage);
        }
    }
}
