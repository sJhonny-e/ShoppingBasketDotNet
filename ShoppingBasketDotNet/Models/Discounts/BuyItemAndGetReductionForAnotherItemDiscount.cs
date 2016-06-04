using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Models.Discounts
{
    public class BuyItemAndGetReductionForAnotherItemDiscount : IDiscount
    {
        private int _itemToBuyId;
        private int _targetItemId;
        private int _quantityToBuy;
        private double _discountPercentage;

        public BuyItemAndGetReductionForAnotherItemDiscount(Item itemToBuy, int quantity, Item targetItem, double discountPercentage)
        {
            _itemToBuyId = itemToBuy.Id;
            _targetItemId = targetItem.Id;
            _quantityToBuy = quantity;
            _discountPercentage = discountPercentage;
        }

        public double GetDiscount(ShoppingBasket shoppingBasket)
        {
            return 0;
        }
    }
}
