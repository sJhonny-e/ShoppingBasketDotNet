﻿using Moq;
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

        [Test]
        public void CalculateTotal_WithDiscounts_SubtractsDiscountsFromTotal()
        {
            var discount1 = new Mock<IDiscount>();
            var discount2 = new Mock<IDiscount>();

            var basket = new ShoppingBasket(new IDiscount[] { discount1.Object, discount2.Object });
            discount1.Setup(d => d.GetDiscount(basket)).Returns(0.5);
            discount2.Setup(d => d.GetDiscount(basket)).Returns(1.5);

            var total = basket.Add(_cinnamonBubka, 10).CalculateTotal();
            Assert.AreEqual(3.0, total); 
        }

        [Test]
        public void GetItem_WhenItemExists_ReturnsItemWithQuantity()
        {
            var basket = new ShoppingBasket(new IDiscount[] { });
            var item = basket.Add(_chocolateBubka, 3)
                .GetItem(_chocolateBubka.Id);
            Assert.AreEqual(_chocolateBubka, item.Key);
            Assert.AreEqual(3, item.Value);
        }

        [Test]
        public void GetItem_WhenItemDoesntExist_ReturnsNullWithZero()
        {
            var basket = new ShoppingBasket(new IDiscount[] { });
            var item = basket.Add(_chocolateBubka, 3)
                .GetItem(1234);
            Assert.IsNull(item.Key);
            Assert.AreEqual(0, item.Value);
        }
    }
}
