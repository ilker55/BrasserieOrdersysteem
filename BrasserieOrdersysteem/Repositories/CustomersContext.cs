using BrasserieOrdersysteem.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.Repositories
{
    public class CustomersContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        public CustomersContext(DbContextOptions<CustomersContext> options) : base(options)
        {
        }
    }
}
