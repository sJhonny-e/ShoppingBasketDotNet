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
            var itemAndQuantity = shoppingBasket.GetItem(_itemId);
            var numberOfItems = itemAndQuantity.Value;
            if (numberOfItems <= _amountToBuy)
                return 0.0; // not enough of the item was bought

            var numberOfItemsFree = 0;

            numberOfItems -= _amountToBuy;
            while (numberOfItems > 0)
            {
                var freeItems = Math.Min( _amountFree , numberOfItems);
                numberOfItemsFree += freeItems;
                numberOfItems -= _amountToBuy + freeItems;
            }

            var item = itemAndQuantity.Key;
            return item.Price * numberOfItemsFree;
        }
    }
}
