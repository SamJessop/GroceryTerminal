using GroceryTerminal.Interfaces;
using System;
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

        public void AddProduct(string name, decimal price, int specialNumber, decimal specialPrice)
        {
            _products.Add(new Product(name, price, new MultiBuySpecial(specialNumber, specialPrice)));
        }

        public void AddProduct(string name, decimal price)
        {
            _products.Add(new Product(name, price));
        }

        public void ScanProduct(string productName)
        {
            if (!_products.Any(x => x.Name == productName))
            {
                throw new Exception("Product not found");
            }

            var product = _products.FirstOrDefault(x => x.Name == productName);

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
    }
}
