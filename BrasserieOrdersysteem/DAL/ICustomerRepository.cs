using BrasserieOrdersysteem.Shared.Models;

namespace BrasserieOrdersysteem.DAL
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer? GetCustomerByID(int customerId);
        void AddCustomer(Customer customer, bool softSave = false);
        void UpdateCustomer(Customer customer, bool softSave = false);
        bool DeleteCustomer(int customerId, bool softSave = false);
        void Save();
    }
}
