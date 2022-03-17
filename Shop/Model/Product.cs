using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    internal class Product
    {
        int id;
        string name;
        int price;

        public Product()
        {

        }

        public Product(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
    }
}
