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
            var scannedProduct = new ScannedProduct(new Product("A", price));
            scannedProduct.TimesScanned = timesScanned;

            // Act
            var result = testClass.Calculate(scannedProduct);


            // Assert
            result.Should().Be(expectedResult);
        }

        public void Calculate_calls_specials_calculate_method_if_product_has_special()
        {
            var specialMock = new Mock<ISpecial>();

            var testClass = new ProductPriceCalculator();
            var product = new Product("A", 10M);
            product.Special = specialMock.Object;

            var scannedProduct = new ScannedProduct(product);

            // Act
            testClass.Calculate(scannedProduct);

            // Assert
            specialMock.Verify(x => x.CalculatePrice(scannedProduct), Times.Once);
        }
    }
}
