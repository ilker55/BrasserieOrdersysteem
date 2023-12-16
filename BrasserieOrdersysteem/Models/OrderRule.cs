namespace BrasserieOrdersysteem.Models
{
    public class OrderRule
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }

        public Product Product { get; set; }
    }
}
