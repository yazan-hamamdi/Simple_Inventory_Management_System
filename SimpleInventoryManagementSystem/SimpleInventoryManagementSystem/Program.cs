namespace SimpleInventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inventory = new Inventory();
            var running = true;

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

                        string name = InputHelper.ReadString("Enter product name: ");
                        decimal price = InputHelper.ReadDecimal("Enter price: ", 1);
                        int quantity = InputHelper.ReadInt("Enter quantity: ", 0);

                        try
                        {
                            inventory.Add(new Product(name, price, quantity));
                            Console.WriteLine("Product added successfully.");
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine($"Error: Product is null { ex.Message }");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Failed to add product: { ex.Message }");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Failed to add product: {ex.Message}");
                        }

                        break;

                    case "2":

                        inventory.DisplayProducts();

                        break;

                    case "3":

                        string Name = InputHelper.ReadString("Enter the name of the product to edit: ");
                        decimal Price = InputHelper.ReadDecimal("Enter new price: ", 1);
                        int Quantity = InputHelper.ReadInt("Enter new quantity: ", 0);

                        try
                        {
                            inventory.Edit(Name, Price, Quantity);
                            Console.WriteLine("Product updated successfully.");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine($"Error: { ex.Message }");
                        }
                                     
                        break;

                    case "4":

                        string deleteName = InputHelper.ReadString("Enter the name of the product to delete: ");


                        try
                        {
                           inventory.Delete(deleteName);
                       Console.WriteLine("Product deleted successfully");
                       }
                       catch (KeyNotFoundException ex)
                       {
                           Console.WriteLine($"Error: {ex.Message}");
                       }
                        
                        break;

                    case "5":

                        string searchName = InputHelper.ReadString("Enter the name of the product to search: ");

                        try
                        {
                            var product = inventory.SearchByName(searchName);
                            if (product != null)
                                Console.WriteLine(product);
                            else
                                Console.WriteLine("Product not found");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

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
