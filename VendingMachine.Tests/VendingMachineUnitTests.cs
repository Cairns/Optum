namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        public static VendingMachine CreateVendingMachine(Currency currency, IValidationStrategy validationStrategy)
        {
            return new VendingMachine(currency, validationStrategy);
        }

        [Fact]
        public void Display_Should_Show_Insert_Coin_When_No_Coins_Are_Inserted()
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

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
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

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
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            vendingMachine.InsertCoin(coin);
            var displayMessage = vendingMachine.Display();

            // Assert
            Assert.Equal($"{coin.Currency.Symbol}{vendingMachine.CurrentAmount / 100.0:F2}", displayMessage);
        }

        [Theory]
        [ClassData(typeof(InvalidCoinTestData))]
        public void Insert_Coin_Should_Reject_Invalid_Coins_And_Not_Update_Current_Amount(Coin coin)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            vendingMachine.InsertCoin(coin);

            // Assert
            Assert.Equal(0, vendingMachine.CurrentAmount);
        }

        [Theory]
        [ClassData(typeof(InvalidCoinTestData))]
        public void Insert_Coin_Should_Reject_Invalid_Coins_And_Not_Update_Display(Coin coin)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            vendingMachine.InsertCoin(coin);
            var displayMessage = vendingMachine.Display();

            // Assert
            Assert.Equal("INSERT COIN", displayMessage);
        }

        [Theory]
        [ClassData(typeof(InvalidCoinTestData))]
        public void Insert_Coin_Should_Reject_Invalid_Coins_And_Add_To_Coin_Return(Coin coin)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            vendingMachine.InsertCoin(coin);
            var returnedCoins = vendingMachine.CoinReturn;

            // Assert
            Assert.Contains(coin, returnedCoins);
        }
    }
}
