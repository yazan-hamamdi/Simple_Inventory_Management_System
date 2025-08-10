
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
            if (IsNotValid(product))
                return false;

            var existingProduct = CheckIfExist(product);

            if (existingProduct != null)
            {
                IncreaseQuantity(existingProduct, product.Quantity);
            }
            else
            {
                Products.Add(product);
            }

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
        public bool Edit(Product product ) 
        {
            if (IsNotValid(product))
            { return false; }

            var existingProduct = CheckIfExist(product);
            if (existingProduct == null)
                return false;

            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;

            return true;
        }
        public bool Delete(Product product) 
        {
            if (IsNotValid(product))
            { return false; }
            var existingProduct = CheckIfExist(product);

            if (existingProduct == null)
            { return false; }

            if (existingProduct.Quantity > 1)
            {
                DecreaseQuantity(existingProduct);
                return true;
            }
            else
            {
                Products.Remove(existingProduct);
                return true;
            }
        }
        public void SearchFor(Product product)
        {
            if (product == null) { return ; }
            var existingProduct = CheckIfExist(product);
            if (existingProduct != null)
            {
                Console.WriteLine($"{existingProduct}");
                return;
            }
            Console.WriteLine("There is no product with this name.");
        }
        public bool IsNotValid(Product product)
        {
            return (product == null || product.Price < 1 || product.Quantity < 0);
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

        public Product CheckIfExist(Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            return existingProduct;
        }
    }
}
