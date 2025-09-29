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
    }
}
