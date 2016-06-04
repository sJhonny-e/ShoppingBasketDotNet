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
    }
}
