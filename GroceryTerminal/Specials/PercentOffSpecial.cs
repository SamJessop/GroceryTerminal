namespace GroceryTerminal.Specials
{
    public class PercentOffSpecial : ISpecial
    {
        public int PercentOff { get; set; }

        public decimal CalculatePrice(ScannedProduct scannedProduct)
        {
            var productPrice = scannedProduct.Product.Price / 100 * (100 - PercentOff);

            return productPrice * scannedProduct.TimesScanned;
        }
    }
}
