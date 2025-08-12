namespace SimpleInventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Simple Inventory Management ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter product name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter price: ");
                        decimal price;
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 1 )
                        {
                            Console.Write("Invalid price, try again: ");
                        }

                        Console.Write("Enter quantity: ");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity ) || quantity < 0)
                        {
                            Console.Write("Invalid quantity, try again: ");
                        }

                        inventory.Add(new Product(name, price, quantity));
                        Console.WriteLine("Product added successfully.");
                        break;

                    case "2":
                        inventory.DisplayProducts();
                        break;

                    case "3":
                        Console.Write("Enter the name of the product to edit: ");
                        string editName = Console.ReadLine();

                        Console.Write("Enter new price: ");
                        while (!decimal.TryParse(Console.ReadLine(), out price) || price < 1)
                        {
                            Console.Write("Invalid price, try again: ");
                        }

                        Console.Write("Enter new quantity: ");
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0 )
                        {
                            Console.Write("Invalid quantity, try again: ");
                        }

                        if (inventory.Edit(new Product(editName, price, quantity)))
                            Console.WriteLine("Product updated successfully.");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "4":
                        Console.Write("Enter the name of the product to delete: ");
                        string deleteName = Console.ReadLine();

                        if (inventory.Delete(new Product(deleteName, 1, 1)))
                            Console.WriteLine("Product deleted successfully.");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "5":
                        Console.Write("Enter the name of the product to search: ");
                        string searchName = Console.ReadLine();

                        inventory.SearchFor(new Product(searchName, 1, 1));
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Exiting... ");
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
