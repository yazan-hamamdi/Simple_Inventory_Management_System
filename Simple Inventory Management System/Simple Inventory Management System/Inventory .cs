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
        public void DisplayProducts()
        {
            if (!Products.Any()) 
            {
                Console.WriteLine("There are no products yet");
                return;
            }
            foreach (Product product in Products) 
            {
                Console.WriteLine(product);
            }
        }
        public bool Edit(Product product) 
        {
            if (product == null) { return false; }

            var existingProduct = Products.FirstOrDefault(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (existingProduct == null)
                return false;

            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            return true;
        }
        public bool Delete(Product product) 
        {
            if (product == null) { return false; }
            var existingProduct = Products.FirstOrDefault(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (existingProduct != null)
            {
                Products.Remove(existingProduct);
                return true;
            }
            return false;
        }
    }
}
