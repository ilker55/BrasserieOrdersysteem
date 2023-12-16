using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.Repositories
{
    public class CustomersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;

        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }
    }
}
