﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryTerminal
{
    public class PointOfSalesTerminal
    {
        private IList<Product> _products;
        private Dictionary<string, int> _scannedProducts;

        public PointOfSalesTerminal()
        {
            _products = new List<Product>();
            _scannedProducts = new Dictionary<string, int>();
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

            if (_scannedProducts.ContainsKey(productName))
            {
                _scannedProducts[productName]++;
            }
            else
            {
                _scannedProducts.Add(productName, 1);
            }
        }

        public decimal CalculatePrice()
        {
            var total = 0m;

            foreach (var scannedProduct in _scannedProducts)
            {
                var product = _products.FirstOrDefault(x => x.Name == scannedProduct.Key);

                total = total + (product.Price * scannedProduct.Value);
            }

            return total;
        }
    }
}
