using System;

namespace GroceryTerminal
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ISpecial Special { get; set; }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name) || price < 0)
            {
                throw new ArgumentException("Product requires a name and a price 0 or above");
            }

            Name = name;
            Price = price;
        }
    }
}
