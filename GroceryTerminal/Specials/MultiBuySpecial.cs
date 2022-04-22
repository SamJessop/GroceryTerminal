using System;

namespace GroceryTerminal.Specials
{
    public class MultiBuySpecial : ISpecial
    {
        public int Number { get; }

        public decimal Price { get; }

        public MultiBuySpecial(int number, decimal price)
        {
            if (number <= 0 || price <= 0)
            {
                throw new ArgumentException("number and price need to be greater than 0 to be a valid multi buy special");
            }

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
