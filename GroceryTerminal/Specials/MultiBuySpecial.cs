using System;

namespace GroceryTerminal.Specials
{
    public class MultiBuySpecial : ISpecial
    {
        public int Number { get; set; }

        public decimal Price { get; set; }

        public MultiBuySpecial(int number, decimal price)
        {
            Number = number;
            Price = price;
        }

        public decimal CalculatePrice(ScannedProduct scannedProduct)
        {
            var total = 0m;

            var timesScanned = scannedProduct.TimesScanned;

            var specialDealNumber = Decimal.ToInt32(Math.Truncate(Decimal.Divide(scannedProduct.TimesScanned, Number)));

            total += specialDealNumber * Price;

            timesScanned -= specialDealNumber * Number;

            total += scannedProduct.Product.Price * timesScanned;

            return total;
        }
    }
}
