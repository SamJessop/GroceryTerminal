namespace GroceryTerminal
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ISpecial Special { get; set; }

        public Product(string name, decimal price, ISpecial special = null)
        {
            Name = name;
            Price = price;
            Special = special;
        }
    }
}
