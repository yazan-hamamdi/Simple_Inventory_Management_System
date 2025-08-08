using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    public class Inventory
    {
        public List<Product> Products { get; private set; }
        public Inventory(List<Product> products)
        {
            this.Products = products;
        }
        public Inventory()
        {
            this.Products = new List<Product>();
        }
        public bool Add(Product product)
        { 
            if (product == null)
            {
                return false;
            }
            Products.Add(product);
            return true;
        }
    }
}
