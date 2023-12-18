using BrasserieOrdersysteem.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using BrasserieOrdersysteem.DAL;

namespace BrasserieOrdersysteem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
            => this.customerRepository = customerRepository;

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
            // Return all customers
            => customerRepository.GetCustomers();

        // GET: api/Customers/16
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            // Find customer by ID and return it. Return NotFound if not exist
            var customer = customerRepository.GetCustomerByID(id);
            return customer != null ? customer : NotFound();
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            // Add new customer and save
            customerRepository.AddCustomer(customer);

            // Return new customer
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/Customers/16
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            // Validate customer ID and model
            if (id != customer.Id)
                return BadRequest();

            // Check if customer exists
            customerRepository.UpdateCustomer(customer);

            // Return updates customer
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/16
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            // Delete customer and return NoContent on success, NotFound otherwise
            return customerRepository.DeleteCustomer(id)
                ? NoContent()
                : NotFound();
        }
    }
}
