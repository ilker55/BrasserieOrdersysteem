using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderSystemContext context;

        public CustomerRepository(OrderSystemContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        public IEnumerable<Customer> GetAll()
            => context.Customers.ToList();

        public Customer? GetByID(int customerId)
            => context.Customers.Find(customerId);

        public void Insert(Customer customer)
            => context.Customers.Add(customer);

        public void Update(Customer customer)
            => context.Entry(customer).State = EntityState.Modified;

        public bool Delete(int customerId)
        {
            var customer = context.Customers.Find(customerId);
            if (customer == null) return false;
            context.Customers.Remove(customer);
            return true;
        }

        public void Save() => context.SaveChanges();
    }
}
