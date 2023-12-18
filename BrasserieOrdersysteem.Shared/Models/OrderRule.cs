namespace BrasserieOrdersysteem.Shared.Models
{
    public class OrderRule
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }

        public virtual Product Product { get; set; }
    }
}
