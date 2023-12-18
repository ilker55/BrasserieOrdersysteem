namespace BrasserieOrdersysteem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<OrderRule> OrderRules { get; } = new List<OrderRule>();

        // Avoid compiled warnings for uninitialized non-nullable properties
        public Product(string name, double price, string? description = null)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
