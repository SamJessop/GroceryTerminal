using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace GroceryTerminal.Tests
{
    [TestFixture]
    public class ProductPriceCalculatorTests
    {
        [TestCase(10, 1, 10)]
        [TestCase(5.5, 2, 11)]
        [TestCase(100, 0, 0)]
        public void Calculate_calculates_price_of_scanned_product(decimal price, int timesScanned, decimal expectedResult)
        {
            var testClass = new ProductPriceCalculator();

            // Act
            var result = testClass.Calculate(new ScannedProduct { Product = new Product("A", price), TimesScanned = timesScanned });

            // Assert
            result.Should().Be(expectedResult);
        }

        public void Calculate_calls_specials_calculate_method_if_product_has_special()
        {
            var specialMock = new Mock<ISpecial>();

            var testClass = new ProductPriceCalculator();
            var product = new Product("A", 10M);
            product.Special = specialMock.Object;

            var scannedProduct = new ScannedProduct { Product = product, TimesScanned = 1 };

            // Act
            testClass.Calculate(scannedProduct);

            // Assert
            specialMock.Verify(x => x.CalculatePrice(scannedProduct), Times.Once);
        }
    }
}
