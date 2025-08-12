
namespace SimpleInventoryManagementSystem
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product(string name) { Name = name; }

        public Product() { Name = string.Empty; }

        public int DecreaseQuantity(int quantity = 1)
        {
            if (quantity < 1)
                return 0;

            if (quantity >= this.Quantity)
            {
                this.Quantity = 0;
            }
            else
            {
                this.Quantity -= quantity;
            }

            return this.Quantity;
        }

        public override string ToString() 
        {
            return $"Product Name is:{Name} Product Price is: {Price} Product Quantity is: {Quantity}";
        } 

    }
}
