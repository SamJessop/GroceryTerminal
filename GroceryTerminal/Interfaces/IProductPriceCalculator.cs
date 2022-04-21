using System.Collections.Generic;

namespace GroceryTerminal.Interfaces
{
    interface IProductPriceCalculator
    {
        decimal Calculate(ScannedProduct scannedProduct);
    }
}
