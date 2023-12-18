using BrasserieOrdersysteem.Models;

namespace BrasserieOrdersysteem.DAL
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer? GetCustomerByID(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        void Save();
    }
}
