using Moq;
using NUnit.Framework;
using ShoppingBasketDotNet.Models;
using ShoppingBasketDotNet.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Tests.Models.Discounts
{
    [TestFixture]
    public class BuyCertainAmountAndGetAdditionalAmountForFreeDiscountTests
    {
        private static Item _ohHenryBar = new Item(1, "Oh henry! bar", 2.5);

        [Test]
        public void GetDiscount_ForEmptyBasket_Returns_0()
        {
            var basket = new Mock<ShoppingBasket>(null);
            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);
            Assert.AreEqual(0, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForQualifyingBasket_AppliesDiscount()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_ohHenryBar.Id)).Returns(new KeyValuePair<Item, int>(_ohHenryBar, 5));

            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);

            Assert.AreEqual(2 * _ohHenryBar.Price, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForQualifyingBasketWithLessThanMaximumAmountOfFreeItems_AppliesDiscountCorrectly()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_ohHenryBar.Id)).Returns(new KeyValuePair<Item, int>(_ohHenryBar, 4));

            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);

            Assert.AreEqual(1 * _ohHenryBar.Price, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForTwiceQualifyingBasket_AppliesDiscountTwice()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_ohHenryBar.Id)).Returns(new KeyValuePair<Item, int>(_ohHenryBar, 9));

            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);

            Assert.AreEqual(3 * _ohHenryBar.Price, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForNonQualifyingBasket_DoesntApplyDiscount()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_ohHenryBar.Id)).Returns(new KeyValuePair<Item, int>(_ohHenryBar, 3));

            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);

            Assert.AreEqual(0.0, discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForBasketQualifyingExactlyThreeTimes_AppliesDiscountExaclyThrice()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_ohHenryBar.Id)).Returns(new KeyValuePair<Item, int>(_ohHenryBar, 15));

            var discount = new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_ohHenryBar, 3, 2);

            Assert.AreEqual(6 * _ohHenryBar.Price, discount.GetDiscount(basket.Object));
        }
    }
}
