﻿using Moq;
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
    public class BuyItemAndGetReductionForAnotherItemDiscountTests
    {
        private static Item _joojiFruits = new Item(1, "jooji fruits", 1.0);
        private static Item _popcorn = new Item(2, "popcorn", 2.5);

        private BuyItemAndGetReductionForAnotherItemDiscount _discount;

        [SetUp]
        public void Setup()
        {
            _discount = new BuyItemAndGetReductionForAnotherItemDiscount(_joojiFruits, 3, _popcorn, 0.25);
        }

        [Test]
        public void GetDiscount_ForEmptyBasket_Returns_0()
        {
            var basket = new Mock<ShoppingBasket>(null);
            Assert.AreEqual(0, _discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForABasketThatQualifies_AppliesDiscount()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_joojiFruits.Id)).Returns(new KeyValuePair<Item, int>(_joojiFruits, 4));
            basket.Setup(b => b.GetItem(_popcorn.Id)).Returns(new KeyValuePair<Item, int>(_popcorn, 3));

            Assert.AreEqual(0.25 * 2.5, _discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForABasketThatQualifiesTwice_AppliesDiscountTwice()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_joojiFruits.Id)).Returns(new KeyValuePair<Item, int>(_joojiFruits, 6));
            basket.Setup(b => b.GetItem(_popcorn.Id)).Returns(new KeyValuePair<Item, int>(_popcorn, 3));

            Assert.AreEqual(2 * 0.25 * 2.5, _discount.GetDiscount(basket.Object));
        }

        [Test]
        public void GetDiscount_ForABasketThatDoesntQualify_DoesntApplyDiscount()
        {
            var basket = new Mock<ShoppingBasket>(null);
            basket.Setup(b => b.GetItem(_joojiFruits.Id)).Returns(new KeyValuePair<Item, int>(_joojiFruits, 2));
            basket.Setup(b => b.GetItem(_popcorn.Id)).Returns(new KeyValuePair<Item, int>(_popcorn, 3));

            Assert.AreEqual(0.0, _discount.GetDiscount(basket.Object));
        }
    }
}
