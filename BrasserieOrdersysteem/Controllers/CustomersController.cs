using BrasserieOrdersysteem.Models;
using Microsoft.AspNetCore.Mvc;
using BrasserieOrdersysteem.DAL.Interfaces;

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
        public ActionResult<IList<Customer>> GetCustomers()
            // Return all customers
            => customerRepository.GetAll().ToList();

        // GET: api/Customers/16
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            // Return customer found by ID, otherwise NotFound
            var customer = customerRepository.GetByID(id);
            return customer != null ? customer : NotFound();
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            // Add new customer and save
            customerRepository.Insert(customer);
            customerRepository.Save();

            // Get and return new customer
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // PUT: api/Customers/16
        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            // Validate customer ID and model
            if (id != customer.Id)
                return BadRequest();

            // Update customer and save
            customerRepository.Update(customer);
            customerRepository.Save();

            // Get and return updated customer
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/16
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            // Delete customer by ID and save
            var deleted = customerRepository.Delete(id);
            customerRepository.Save();

            //Return NoContent on success, otherwise NotFound
            return deleted ? NoContent() : NotFound();
        }
    }
}
