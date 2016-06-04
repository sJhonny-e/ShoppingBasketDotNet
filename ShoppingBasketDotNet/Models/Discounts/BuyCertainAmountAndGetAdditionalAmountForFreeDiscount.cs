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
        private int _itemId;
        private int _amountToBuy;
        private int _amountFree;
        public BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(Item item, int amountToBuy, int amountFree)
        {
            _itemId = item.Id;
            _amountFree = amountFree;
            _amountToBuy = amountToBuy;
        }

        public double GetDiscount(ShoppingBasket shoppingBasket)
        {
            return 0.0;
        }
    }
}
