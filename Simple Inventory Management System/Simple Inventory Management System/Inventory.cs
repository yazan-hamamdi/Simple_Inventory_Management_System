
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
            {
                existingProduct.Price = product.Price;
                IncreaseQuantity(existingProduct, product.Quantity);
            }
            else
            {
                Products.Add(product);
            }

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

        public void Edit(Product product ) 
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");

            var existingProduct = GetProductByName(product.Name);

            if (existingProduct == null)
                throw new InvalidOperationException("Product does not exist in the inventory");

            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

        }

        public void Delete(string name) 
        {
            var existingProduct = GetProductByName(name);

            if (existingProduct == null)
                throw new InvalidOperationException("Product does not exist in the inventory");

            if (existingProduct.Quantity > 1)
            {
                DecreaseQuantity(existingProduct);
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

        private int IncreaseQuantity(Product product ,int quantity = 1)
        {
            if (product == null || quantity < 1)
            {
                return 0;
            }
            return product.Quantity += quantity;
        }

        private int DecreaseQuantity(Product product, int quantity = 1)
        {
            if (product == null || quantity < 1) 
                return 0;

            if (quantity >= product.Quantity)
            {
                product.Quantity = 0;
            }
            else
            {
                product.Quantity -= quantity;
            }

            return product.Quantity;
        }

        public Product GetProductByName(string name)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return existingProduct;
        }

    }
}
