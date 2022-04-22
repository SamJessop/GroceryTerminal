using FluentAssertions;
using GroceryTerminal.Specials;
using NUnit.Framework;

namespace GroceryTerminal.Tests.Specials
{
    [TestFixture]
    public class PercentOffSpecialTests
    {
        [TestCase(10, 1, 50, 5)]
        [TestCase(10, 1, 30, 7)]
        [TestCase(10, 2, 30, 14)]
        public void CalculatePrice_calculates_correct_price(decimal productPrice, int timesScanned, int percentOff, decimal expectedPrice)
        {
            var testClass = new PercentOffSpecial { PercentOff = percentOff };

            var scannedProduct = new ScannedProduct { Product = new Product("A", productPrice, testClass), TimesScanned = timesScanned };

            // Act
            var result = testClass.CalculatePrice(scannedProduct);

            // Assert
            result.Should().Be(expectedPrice);
        }
    }
}
