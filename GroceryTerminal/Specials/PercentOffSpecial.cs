using System;

namespace GroceryTerminal.Specials
{
    public class PercentOffSpecial : ISpecial
    {
        public int PercentOff { get; }

        public PercentOffSpecial(int percentOff)
        {
            if (percentOff <= 0 || percentOff > 100)
            {
                throw new ArgumentException("percent off needs be a number between 1 and 100 to be a valid percent off special");
            }

            PercentOff = percentOff;
        }

        public decimal CalculatePrice(ScannedProduct scannedProduct)
        {
            var productPrice = scannedProduct.Product.Price / 100 * (100 - PercentOff);

            return productPrice * scannedProduct.TimesScanned;
        }
    }
}
