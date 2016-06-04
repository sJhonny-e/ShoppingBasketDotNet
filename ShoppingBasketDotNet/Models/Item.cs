using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDotNet.Models
{
    public class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public Item(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
