namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Product product = new Product("ee", 1, 1);
            Product product1 = new Product("ee", 1, 1);
            Product product2 = new Product("ee", 1, 1);

            inventory.Products.Add(product);
            inventory.Products.Add(product1);
            inventory.Products.Add(product2);

            inventory.DisplayProducts();

        }
    }
}
