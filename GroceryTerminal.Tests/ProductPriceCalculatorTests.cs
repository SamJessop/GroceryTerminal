using FluentAssertions;
using NUnit.Framework;

namespace GroceryTerminal.Tests
{
    public class ProductPriceCalculatorTests
    {
        [TestCase(10, 1, 10)]
        [TestCase(5.5, 2, 11)]
        [TestCase(100, 0, 0)]
        [TestCase(-10, 1, -10)]
        public void Calculate_calculates_price_of_scanned_product(decimal price, int timesScanned, decimal expectedResult)
        {
            var testClass = new ProductPriceCalculator();

            // Act
            var result = testClass.Calculate(new ScannedProduct { Product = new Product("A", price), TimesScanned = timesScanned });

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
