using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    public class Inventory
    {
        public List<Product> products { get; set; }
        public Inventory(List<Product> products)
        {
            this.products = products;
        }
        public Inventory()
        {
            this.products = new List<Product>();
        }
    }
}
