using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Models
{
    public class ShoppingBasket
    {
        private Dictionary<Item, int> _items;
        private IEnumerable<IDiscount> _discounts;

        public ShoppingBasket(IEnumerable<IDiscount> discounts)
        {
            _items = new Dictionary<Item, int>(ItemsComparer.Comparer);
            _discounts = discounts;
        }

        public ShoppingBasket Add(Item item, int quantity)
        {
            if (!_items.ContainsKey(item))
            {
                _items.Add(item, 0);
            }

            _items[item] += quantity;

            return this;
        }

        public double CalculateTotal()
        {
            var withoutDiscounts = _items.Select(pair => pair.Key.Price * pair.Value)
                .Sum();

            var discountTotal = 0;
            foreach (var discount in _discounts)
            {
                discountTotal += discount.GetDiscount(this);
            }

            return withoutDiscounts - discountTotal;
        }

        // Making sure we only store one record per item
        private class ItemsComparer : IEqualityComparer<Item>
        {
            public static ItemsComparer Comparer = new ItemsComparer();

            public bool Equals(Item x, Item y)
            {
                if (x == null && y == null)
                    return true;

                if (x == null || y == null)
                    return false;

                return x.Id == y.Id;
            }

            public int GetHashCode(Item obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
