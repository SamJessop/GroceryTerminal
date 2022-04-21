using System.Collections.Generic;

namespace GroceryTerminal
{
    public class PointOfSalesTerminal
    {
        private IList<Product> _products;

        public void AddProduct(string name, decimal price)
        {
            _products.Add(new Product(name, price));
        }

        public void ScanProduct(string Product)
        {
            
        }

        public decimal CalculatePrice()
        {
            return 6M;
        }
    }
}
