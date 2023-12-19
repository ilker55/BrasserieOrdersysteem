namespace BrasserieOrdersysteem.Models
{
    public class OrderRule
    {
        public int Id { get; set; }
        public int Units { get; set; }
        public decimal PricePerUnit { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal GetTotalPrice() => PricePerUnit * Units;
    }
}
