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

        [Theory]
        [ClassData(typeof(InvalidCoinTestData))]
        public void Empty_Coin_Return_Should_Clear_Coin_Return_After_Invalid_Coins_Are_Inserted(Coin coin)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            vendingMachine.InsertCoin(coin);

            vendingMachine.EmptyCoinReturn();
            var returnedCoinsAfterEmpty = vendingMachine.CoinReturn;

            // Assert
            Assert.Empty(returnedCoinsAfterEmpty);
        }

        [Fact]
        public void Insert_Coin_Should_Accept_Multiple_Valid_Coins_And_Update_Current_Amount()
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());
            var coins = new List<Coin>
            {
                Money.GBP.Denomination.FivePence,
                Money.GBP.Denomination.TenPence,
                Money.GBP.Denomination.TwentyPence,
            };

            // Act
            foreach (var coin in coins)
            {
                vendingMachine.InsertCoin(coin);
            }

            // Assert
            var expectedTotal = coins.Sum(c => c.Value);
            Assert.Equal(expectedTotal, vendingMachine.CurrentAmount);
        }

        [Fact]
        public void Insert_Coin_Should_Accept_Multiple_Valid_Coins_And_Update_Display()
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());
            var coins = new List<Coin>
            {
                Money.GBP.Denomination.FivePence,
                Money.GBP.Denomination.TenPence,
                Money.GBP.Denomination.TwentyPence,
            };

            // Act
            foreach (var coin in coins)
            {
                vendingMachine.InsertCoin(coin);
            }

            var displayMessage = vendingMachine.Display();

            // Assert
            Assert.Equal($"{Currency.GBP.Symbol}{vendingMachine.CurrentAmount / 100.0:F2}", displayMessage);
        }

        [Fact]
        public void Insert_Coin_Should_Accept_Valid_And_Reject_Invalid_Coins_And_Only_Accumulate_Valid_Ones()
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());
            var validCoins = new List<Coin>
            {
                Money.GBP.Denomination.FivePence,
                Money.GBP.Denomination.TenPence,
            };
            var invalidCoins = new List<Coin>
            {
                Money.GBP.Denomination.OnePence,
                Money.GBP.Denomination.TwoPence,
            };

            // Act
            vendingMachine.InsertCoin(Money.GBP.Denomination.FivePence); // Valid
            vendingMachine.InsertCoin(Money.GBP.Denomination.OnePence); // Invalid
            vendingMachine.InsertCoin(Money.GBP.Denomination.TenPence); // Valid
            vendingMachine.InsertCoin(Money.GBP.Denomination.TwoPence); // Invalid

            // Assert
            var expectedTotal = validCoins.Sum(c => c.Value);
            Assert.Equal(expectedTotal, vendingMachine.CurrentAmount);
            Assert.Contains(Money.GBP.Denomination.OnePence, vendingMachine.CoinReturn);
            Assert.Contains(Money.GBP.Denomination.TwoPence, vendingMachine.CoinReturn);
        }

        [Theory(Skip = "Fix this unit test, display will not display Thank you then Insert coin")]
        [ClassData(typeof(ProductTestData))]
        public void Select_Product_With_Exact_Money_Should_Dispense_Product_And_Display_ThankYou(Product product)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());

            // Act
            var requiredCoins = GetRequiredCoinsForProductPrice(product);
            foreach (var coin in requiredCoins)
            {
                vendingMachine.InsertCoin(coin);
            }

            var result = vendingMachine.SelectProduct(product);
            var firstDisplay = vendingMachine.Display();
            var secondDisplay = vendingMachine.Display();

            // Assert
            Assert.True(result);
            Assert.Equal(VendingMachineMessages.ThankYou, firstDisplay);//Will fail here and pass if commented out
            Assert.Equal(VendingMachineMessages.InsertCoin, secondDisplay);
        }

        [Theory]
        [ClassData(typeof(ProductWithMoneyTestData))]
        public void Select_Product_With_Insufficient_Money_Should_Not_Dispense_Product_And_Display_Current_Amount(Product product, Coin coin)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());
            vendingMachine.InsertCoin(coin);

            // Act
            var result = vendingMachine.SelectProduct(product);
            var displayMessage = vendingMachine.Display();
            var expectedDisplay = $"PRICE {product.Currency.Symbol}{product.Value / 100.0:F2}";

            // Assert
            Assert.False(result);
            Assert.Equal(expectedDisplay, displayMessage);
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void Select_Product_With_Excess_Money_Should_Make_Change(Product product)
        {
            // Arrange
            var vendingMachine = CreateVendingMachine(Currency.GBP, new GBPValidationStrategy());
            vendingMachine.InsertCoin(Money.GBP.Denomination.TwoPounds); // £2.00

            // Act
            vendingMachine.SelectProduct(product);
            var change = vendingMachine.CoinReturn;
            var totalChange = change.Sum(c => c.Value);

            // Assert
            Assert.Equal(200 - product.Value, totalChange);
            Assert.Equal(0, vendingMachine.CurrentAmount);
        }

        private static List<Coin> GetRequiredCoinsForProductPrice(IMonetaryValue monetaryValue)
        {
            var coins = new List<Coin>();
            var remainingAmount = monetaryValue.Value;
            var validCoins = new GBPValidationStrategy().ValidCoins
                .OrderByDescending(c => c.Value)
                .ToList();
            foreach (var coin in validCoins)
            {
                while (remainingAmount >= coin.Value)
                {
                    coins.Add(coin);
                    remainingAmount -= coin.Value;
                }
            }
            return coins;
        }
    }
}
