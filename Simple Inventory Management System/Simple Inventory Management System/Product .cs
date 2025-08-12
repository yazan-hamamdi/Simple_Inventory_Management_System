
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
            this.Quantity = quantity;
        }
        public Product() {Name = string.Empty;}

    public override string ToString() 
        {
            return $"Product Name is:{Name} Product Price is: {Price} Product Quantity is: {Quantity}";
        }
    }
}
