namespace BrasserieOrdersysteem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        public virtual ICollection<OrderRule> OrderRules { get; set; } = new List<OrderRule>();
    }
}
