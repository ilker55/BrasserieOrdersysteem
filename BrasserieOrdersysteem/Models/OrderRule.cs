namespace BrasserieOrdersysteem.Models
{
    public class OrderRule
    {
        public int Id { get; set; }
        public double Units { get; set; }
        public double PricePerUnit { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public double GetTotalPrice() => PricePerUnit * Units;
    }
}
