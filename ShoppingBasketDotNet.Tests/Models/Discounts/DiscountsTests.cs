using Moq;
using NUnit.Framework;
using ShoppingBasketDotNet.Models;
using ShoppingBasketDotNet.Models.Discounts;
using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Tests.Models.Discounts
{
    [TestFixture]
    public class DiscountsTests
    {
        private static Item _joojiFruits = new Item(1, "jooji fruits", 1.0);
        private static Item _popcorn = new Item(2, "popcorn", 2.5);


        [Test]
        public void GetDiscount_ForEmptyBasket_Returns_0()
        {
            var basket = new Mock<ShoppingBasket>(null);
            var discount = new BuyItemAndGetReductionForAnotherItemDiscount(_joojiFruits, 3, _popcorn, 0.25);
            Assert.AreEqual(0, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForABasketThatQualifies_AppliesDiscount()
        {
            var basket = new Mock<ShoppingBasket>(null);
            var discount = new BuyItemAndGetReductionForAnotherItemDiscount(_joojiFruits, 3, _popcorn, 0.25);
            Assert.AreEqual(0.25 * 2.5, discount.GetDiscount(basket.Object));
        }
    }
}
