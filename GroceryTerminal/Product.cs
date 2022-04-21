namespace GroceryTerminal
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public MultiBuySpecial MultiBuySpecial { get; set; }

        public Product(string name, decimal price, MultiBuySpecial multiBuySpecial = null)
        {
            Name = name;
            Price = price;
            MultiBuySpecial = multiBuySpecial;
        }
    }
}
