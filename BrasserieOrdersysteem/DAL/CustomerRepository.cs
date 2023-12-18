using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderSystemContext context;

        public CustomerRepository(OrderSystemContext context)
            => this.context = context;

        public IEnumerable<Customer> GetCustomers()
            => context.Customers.ToList();

        public Customer? GetCustomerByID(int customerId)
            => context.Customers.Find(customerId);

        public void AddCustomer(Customer customer)
            => context.Customers.Add(customer);

        public void UpdateCustomer(Customer customer)
            => context.Entry(customer).State = EntityState.Modified;

        public bool DeleteCustomer(int customerId)
        {
            var customer = context.Customers.Find(customerId);
            if (customer == null) return false;
            context.Customers.Remove(customer);
            return true;
        }

        public void Save() => context.SaveChanges();
    }
}
