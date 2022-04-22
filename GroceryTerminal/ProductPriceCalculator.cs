using GroceryTerminal.Interfaces;
using System;

namespace GroceryTerminal
{
    public class ProductPriceCalculator : IProductPriceCalculator
    {
        public decimal Calculate(ScannedProduct scannedProduct)
        {
            if (scannedProduct.Product.Special!= null)
            {
                return scannedProduct.Product.Special.CalculatePrice(scannedProduct);
            }
            else
            {
                return scannedProduct.Product.Price * scannedProduct.TimesScanned;
            }
        }
    }
}
