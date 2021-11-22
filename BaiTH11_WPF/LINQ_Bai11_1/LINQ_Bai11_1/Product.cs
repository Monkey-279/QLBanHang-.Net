using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Bai11_1
{
    internal class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string[] Colors { get; set; }
        public int Brand { get; set; }
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }
        public override string ToString()
        {
            return $" || {ID,-5} {Name,-10} {Price,5} {string.Join(",", Colors)}";
        }
    }
}
