using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            this.quantity = quantity;
        }
        public Product()
        {
       
        }
    }
}
