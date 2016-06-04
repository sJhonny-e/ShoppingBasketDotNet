using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Models.Interfaces
{
    public interface IDiscount
    {
        int GetDiscount(ShoppingBasket shoppingBasket);
    }
}
