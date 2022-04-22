using GroceryTerminal.Exceptions;
using GroceryTerminal.Interfaces;
using GroceryTerminal.Specials;
using System.Collections.Generic;
using System.Linq;

namespace GroceryTerminal
{
    public class PointOfSalesTerminal
    {
        private IList<Product> _products;
        private IList<ScannedProduct> _scannedProducts;
        private IProductPriceCalculator _productPriceCalculator;

        public PointOfSalesTerminal()
        {
            _products = new List<Product>();
            _scannedProducts = new List<ScannedProduct>();

            // Should be injected into a constructor with DI 
            _productPriceCalculator = new ProductPriceCalculator();
        }

        public void AddProduct(string name, decimal price)
        {
            _products.Add(new Product(name, price));
        }

        public void AddMultiBuySpecial(string productName, int specialNumber, decimal specialPrice)
        {
            var product = GetProduct(productName);
            product.Special = new MultiBuySpecial(specialNumber, specialPrice);
        }

        public void AddPercentOfflSpecial(string productName, int percentOff)
        {
            var product = GetProduct(productName);
            product.Special = new PercentOffSpecial(percentOff);
        }

        public void ScanProduct(string productName)
        {
            var product = GetProduct(productName);

            if (_scannedProducts.Any(x => x.Product.Name == productName))
            {
                _scannedProducts.FirstOrDefault(x => x.Product.Name == productName).TimesScanned++;
            }
            else
            {
                _scannedProducts.Add(new ScannedProduct { Product = product, TimesScanned = 1 });
            }
        }

        public decimal CalculatePrice()
        {
            var total = 0M;

            foreach (var scannedProduct in _scannedProducts)
            {
                total += _productPriceCalculator.Calculate(scannedProduct);
            }

            return total;
        }

        private Product GetProduct(string productName)
        {
            var product = _products.FirstOrDefault(x => x.Name == productName);

            if (product == null)
            {
                throw new ProductNotFoundException("Product not found");
            }

            return product;
        }
    }
}
