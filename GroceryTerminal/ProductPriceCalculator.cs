using GroceryTerminal.Interfaces;
using System;

namespace GroceryTerminal
{
    public class ProductPriceCalculator : IProductPriceCalculator
    {
        public decimal Calculate(ScannedProduct scannedProduct)
        {
            var total = 0m;

            var product = scannedProduct.Product;
            var productScanned = scannedProduct.TimesScanned;

            if (product.MultiBuySpecial != null)
            {
                var specialDealNumber = Decimal.ToInt32(Math.Truncate(Decimal.Divide(productScanned, product.MultiBuySpecial.Number)));

                total += specialDealNumber * product.MultiBuySpecial.Price;

                productScanned -= specialDealNumber * product.MultiBuySpecial.Number;
            }

            total += product.Price * productScanned;

            return total;
        }
    }
}
