namespace BrasserieOrdersysteem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Notes { get; set; }
        public DateTime OrderAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public bool Canceled { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderRule> OrderRules { get; set; } = new List<OrderRule>();

        public decimal GetTotalPrice() => OrderRules.Sum(x => x.GetTotalPrice());
    }
}
