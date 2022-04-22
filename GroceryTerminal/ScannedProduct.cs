using System;

namespace GroceryTerminal
{
    public class ScannedProduct
    {
        public Product Product { get; }

        public int TimesScanned { get; set; }

        public ScannedProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Cannot scan a null product");
            }

            Product = product;
            TimesScanned = 1;
        }
    }
}
