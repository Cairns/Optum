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
    }
}
