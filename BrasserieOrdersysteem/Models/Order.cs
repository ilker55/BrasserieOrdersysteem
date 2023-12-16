namespace BrasserieOrdersysteem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Notes { get; set; }
        public DateTime OrderAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? SentAt { get; set; }
        public bool Canceled { get; set; }
        public bool Completed { get; set; }

        public ICollection<OrderRule>? OrderRules { get; set; }
    }
}
