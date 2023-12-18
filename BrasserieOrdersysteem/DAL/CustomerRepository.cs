using BrasserieOrdersysteem.Repositories;
using BrasserieOrdersysteem.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomersContext context;

        public CustomerRepository(CustomersContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetCustomers()
            => context.Customers.ToList();

        public Customer? GetCustomerByID(int customerId)
            => context.Customers.Find(customerId);

        public void AddCustomer(Customer customer, bool softSave = false)
        {
            context.Customers.Add(customer);
            if (!softSave) Save();
        }

        public void UpdateCustomer(Customer customer, bool softSave = false)
        {
            context.Entry(customer).State = EntityState.Modified;
            if (!softSave) Save();
        }

        public bool DeleteCustomer(int customerId, bool softSave = false)
        {
            var customer = context.Customers.Find(customerId);
            if (customer == null) return false;
            context.Customers.Remove(customer);
            if (!softSave) Save();
            return true;
        }

        public void Save() => context.SaveChanges();
    }
}
