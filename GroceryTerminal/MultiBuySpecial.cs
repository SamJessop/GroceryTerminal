namespace GroceryTerminal
{
    public class MultiBuySpecial
    {
        public int Number { get; set; }

        public decimal Price { get; set; }

        public MultiBuySpecial(int number, decimal price)
        {
            Number = number;
            Price = price;
        }
    }
}
