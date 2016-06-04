using Moq;
using NUnit.Framework;
using ShoppingBasketDotNet.Models;
using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Tests.Models
{
    [TestFixture]
    public class ShoppingBasketTests
    {
        private static Item _chocolateBubka = new Item(1, "chocolate bubka", 1.0);
        private static Item _cinnamonBubka = new Item(2, "cinnamon bubka", 0.5);

        [Test]
        public void CalculateTotal_WithoutAnyActiveDiscounts_ReturnsSumOfPrices()
        {
            var basket = new ShoppingBasket(new IDiscount[] { });
            var total = basket.Add(_chocolateBubka, 3)
                .Add(_cinnamonBubka, 5)
                .Add(_cinnamonBubka, 4)
                .CalculateTotal();

            Assert.AreEqual(7.5, total);

        }

        [Test]
        public void CalculateTotal_WithDiscounts_CallsAllDiscountVisitors()
        {
            var discount1 = new Mock<IDiscount>();
            var discount2 = new Mock<IDiscount>();

            var basket = new ShoppingBasket(new IDiscount[] { discount1.Object, discount2.Object });

            basket.Add(_chocolateBubka, 3)
                .CalculateTotal();

            discount1.Verify(d => d.GetDiscount(basket));
            discount2.Verify(d => d.GetDiscount(basket));
        }
    }
}
