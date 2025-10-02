using VendingMachineEventDriven.Models;
using VendingMachineEventDriven.Events;
using Xunit;

namespace VendingMachineEventDriven.Tests
{
    public class VendingMachineTests
    {
        private readonly VendingMachine _sut;
        private CoinInsertedEventArgs? _lastCoinInserted;
        private ProductSelectedEventArgs? _lastProductSelected;
        private ChangeReturnedEventArgs? _lastChangeReturned;

        public VendingMachineTests()
        {
            _sut = new VendingMachine();
            _sut.CoinInserted += (_, args) => _lastCoinInserted = args;
            _sut.ProductSelected += (_, args) => _lastProductSelected = args;
            _sut.ChangeReturned += (_, args) => _lastChangeReturned = args;
        }

        [Fact]
        public void Initial_Display_Shows_InsertCoin()
        {
            Assert.Equal("INSERT COIN", _sut.Display);
        }

        [Theory]
        [InlineData(0.05)]
        [InlineData(0.10)]
        [InlineData(0.20)]
        [InlineData(0.50)]
        [InlineData(1.00)]
        [InlineData(2.00)]
        public void Valid_Coin_Updates_Display_And_Raises_Event(decimal coinValue)
        {
            _sut.InsertCoin(coinValue);

            Assert.Equal($"£{coinValue:N2}", _sut.Display);
            Assert.NotNull(_lastCoinInserted);
            Assert.Equal(coinValue, _lastCoinInserted.Coin.Value);
            Assert.Equal(coinValue, _lastCoinInserted.CurrentBalance);
        }

        [Theory]
        [InlineData(0.01)]
        [InlineData(0.02)]
        public void Invalid_Coin_Is_Returned(decimal coinValue)
        {
            _sut.InsertCoin(coinValue);

            Assert.NotNull(_lastChangeReturned);
            Assert.Equal(coinValue, _lastChangeReturned.Amount);
            Assert.Single(_lastChangeReturned.Coins);
            Assert.Equal(coinValue, _lastChangeReturned.Coins[0].Value);
        }

        [Fact]
        public void Selecting_Product_With_Exact_Money_Dispenses_Product()
        {
            _sut.InsertCoin(1.00m);
            _sut.SelectProduct("Cola");

            Assert.Equal("THANK YOU", _sut.Display);
            Assert.Equal("INSERT COIN", _sut.Display); // Second read
            Assert.NotNull(_lastProductSelected);
            Assert.Equal("Cola", _lastProductSelected.Product.Name);
            Assert.Null(_lastChangeReturned);
        }

        [Fact]
        public void Selecting_Product_With_Insufficient_Money_Shows_Price()
        {
            _sut.InsertCoin(0.20m);
            _sut.SelectProduct("Cola");

            Assert.Equal("PRICE £1.00", _sut.Display);
            Assert.Null(_lastProductSelected);
        }

        [Fact]
        public void Selecting_Product_With_Excess_Money_Returns_Change()
        {
            _sut.InsertCoin(2.00m);
            _sut.SelectProduct("Cola");

            Assert.Equal("THANK YOU", _sut.Display);
            Assert.NotNull(_lastChangeReturned);
            Assert.Equal(1.00m, _lastChangeReturned.Amount);
        }

        [Fact]
        public void Multiple_Coin_Insertions_Accumulate()
        {
            _sut.InsertCoin(0.50m);
            _sut.InsertCoin(0.20m);
            _sut.InsertCoin(0.10m);

            Assert.Equal("£0.80", _sut.Display);
        }
    }
}

