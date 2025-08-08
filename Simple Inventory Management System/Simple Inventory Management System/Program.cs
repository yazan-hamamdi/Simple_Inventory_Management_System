namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Product product = new Product("ee", 1, 1);
            inventory.Products.Add(product);
            foreach (var item in inventory.Products)
            {
                Console.WriteLine(item);
            }
        }
    }
}
