using NUnit.Framework;
using ShoppingBasketDotNet.Models;
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
            var basket = new ShoppingBasket();
            var total = basket.Add(_chocolateBubka, 3)
                .Add(_cinnamonBubka, 5)
                .Add(_cinnamonBubka, 4)
                .CalculateTotal();

            Assert.AreEqual(7.5, total);

        }
    }
}
