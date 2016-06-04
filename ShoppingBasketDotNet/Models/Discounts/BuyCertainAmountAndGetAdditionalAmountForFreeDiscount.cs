using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Models.Discounts
{
    public class BuyCertainAmountAndGetAdditionalAmountForFreeDiscount : IDiscount
    {
        public double GetDiscount(ShoppingBasket shoppingBasket)
        {
            throw new NotImplementedException();
        }
    }
}
