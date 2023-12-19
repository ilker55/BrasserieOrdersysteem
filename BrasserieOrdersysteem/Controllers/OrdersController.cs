using BrasserieOrdersysteem.DAL;
using BrasserieOrdersysteem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieOrdersysteem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
            => this.orderRepository = orderRepository;

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IList<Order>> GetOrders()
            // Return all orders
            => orderRepository.GetAll().ToList();

        // GET: api/Orders/4
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            // Return order found by ID, otherwise NotFound
            var order = orderRepository.GetByID(id);
            return order != null ? order : NotFound();
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            // Add new order and save
            orderRepository.Insert(order);
            orderRepository.Save();

            // Return Created
            return StatusCode(201);
        }

        // PUT: api/Orders/4
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, Order order)
        {
            // Validate order ID and model
            if (id != order.Id)
                return BadRequest();

            // Update order and save
            orderRepository.Update(order);
            orderRepository.Save();

            // Return NoContent
            return NoContent();
        }

        // DELETE: api/Orders/4
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            // Delete order by ID and save
            var deleted = orderRepository.Delete(id);
            orderRepository.Save();

            //Return NoContent on success, otherwise NotFound
            return deleted ? NoContent() : NotFound();
        }
    }
}
