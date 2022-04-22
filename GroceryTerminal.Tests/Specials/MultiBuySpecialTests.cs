using FluentAssertions;
using GroceryTerminal.Specials;
using NUnit.Framework;

namespace GroceryTerminal.Tests.Specials
{
    [TestFixture]
    public class MultiBuySpecialTests
    {
        [TestCase(2, 2, 10, 2, 2)]
        [TestCase(2, 2, 10, 3, 12)]
        public void CalculatePrice_calculates_correct_price(int multiBuySpecialNumber, decimal multiBuySpecialPrice, decimal productPrice, int timesScanned, decimal expectedPrice)
        {
            var testClass = new MultiBuySpecial(multiBuySpecialNumber, multiBuySpecialPrice);

            var scannedProduct = new ScannedProduct { Product = new Product("A", productPrice, testClass), TimesScanned = timesScanned };

            // Act
            var result = testClass.CalculatePrice(scannedProduct);

            // Assert
            result.Should().Be(expectedPrice);
        }
    }
}
