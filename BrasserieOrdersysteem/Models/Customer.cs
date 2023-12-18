namespace BrasserieOrdersysteem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        // Avoid compiled warnings for uninitialized non-nullable properties
        public Customer(string name, string? email = null, string? phone = null)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
