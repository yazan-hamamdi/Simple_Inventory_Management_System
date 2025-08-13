
namespace SimpleInventoryManagementSystem
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

        public void Add(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            if (!IsValid(product))
                throw new ArgumentException("Invalid product : Price must be >= 1 and Quantity >= 0");

            var existingProduct = GetProductByName(product.Name);

            if (existingProduct != null)
                throw new InvalidOperationException("Product already exist try to Edit : ");

            Products.Add(product);
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

        public void Edit(string productName, decimal newPrice, int newQuantity) 
        {
            var existingProduct = GetProductByName(productName);

            if (existingProduct == null)
                throw new InvalidOperationException("Product does not exist in the inventory");

            existingProduct.Price = newPrice;
            existingProduct.Quantity = newQuantity;
        }

        public void Delete(string name) 
        {
            var existingProduct = GetProductByName(name);

            if (existingProduct == null)
                throw new InvalidOperationException("Product does not exist in the inventory");

            if (existingProduct.Quantity > 1)
            {
                existingProduct.DecreaseQuantity();
            }
            else
            {
                Products.Remove(existingProduct);
            }
        }

        public Product SearchFor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be null or empty", nameof(name));

            var existingProduct = GetProductByName(name);
            return existingProduct;
        }

        public bool IsValid(Product product)
        {
            return (product.Price >= 1 && product.Quantity >= 0);
        }

        public Product GetProductByName(string name)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return existingProduct;
        }

    }
}
