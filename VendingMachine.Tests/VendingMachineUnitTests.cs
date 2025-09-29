namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void Display_Should_Show_Insert_Coin_When_No_Coins_Are_Inserted()
        {
            // Arrange
            var vendingMachine = new VendingMachine();

            // Act
            var displayMessage = vendingMachine.Display();

            // Assert
            Assert.Equal("INSERT COIN", displayMessage);
        }

        [Theory]
        [ClassData(typeof(ValidCoinTestData))]
        public void Insert_Coin_Should_Accept_Valid_Coins_And_Update_Current_Amount(Coin coin)
        {
            // Arrange
            var vendingMachine = new VendingMachine();

            // Act
            vendingMachine.InsertCoin(coin);

            // Assert
            Assert.Equal(coin.Value, vendingMachine.CurrentAmount);
        }

        [Theory]
        [ClassData(typeof(ValidCoinTestData))]
        public void Insert_Coin_Should_Accept_Valid_Coins_And_Update_Display(Coin coin)
        {
            // Arrange
            var vendingMachine = new VendingMachine();

            // Act
            vendingMachine.InsertCoin(coin);
            var displayMessage = vendingMachine.Display();

            // Assert
            Assert.Equal($"{coin.Currency.Symbol}{vendingMachine.CurrentAmount / 100.0:F2}", displayMessage);
        }
    }
}
