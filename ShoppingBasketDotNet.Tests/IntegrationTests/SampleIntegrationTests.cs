using NUnit.Framework;
using ShoppingBasketDotNet.Models;
using ShoppingBasketDotNet.Models.Discounts;
using ShoppingBasketDotNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Tests.IntegrationTests
{
    [TestFixture]
    public class SampleIntegrationTests
    {
        private static Item _bread = new Item(1, "bread", 1.0);
        private static Item _butter = new Item(2, "butter", 0.8);
        private static Item _milk = new Item(3, "milk", 1.15);

        private static IDiscount[] _discounts =
        {
            new BuyCertainAmountAndGetAdditionalAmountForFreeDiscount(_milk, 3, 1),
            new BuyItemAndGetReductionForAnotherItemDiscount(_butter, 2 , _bread, 0.5)
        };

        private ShoppingBasket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new ShoppingBasket(_discounts);
        }

        [Test]
        public void OneBread_1Butter_1Milk_TotalIs_2_95()
        {
            var total = _basket.Add(_bread, 1)
                .Add(_butter, 1)
                .Add(_milk, 1)
                .CalculateTotal();

            Assert.AreEqual(2.95, total);
        }

        [Test]
        public void TwoButter_2Bread_TotalIs_3_10()
        {
            var total = _basket.Add(_butter, 2)
                .Add(_bread, 2)
                .CalculateTotal();

            Assert.AreEqual(3.1, total);
        }

        [Test]
        public void FourMilk_TotalIs_3_45()
        {
            var total = _basket.Add(_milk, 4)
                .CalculateTotal();

            Assert.That(Math.Abs(3.45 - total) < 0.0001);   // stupid double-precision...
        }

        [Test]
        public void TwoButter_1Bread_8Milk_TotalIs_9()
        {
            var total = _basket.Add(_butter, 2)
                .Add(_bread, 1)
                .Add(_milk, 8)
                .CalculateTotal();

            Assert.AreEqual(9, total);
        }
    }
}
