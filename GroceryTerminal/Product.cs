namespace GroceryTerminal
{
    public class Product
    {
        string Name { get; set; }

        decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
