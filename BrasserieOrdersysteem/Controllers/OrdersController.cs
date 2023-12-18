using BrasserieOrdersysteem.DAL;
using BrasserieOrdersysteem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        // POST: api/Orders
        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            // Add new order and save
            orderRepository.AddOrder(order);
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

            // Update customer and save
            orderRepository.UpdateOrder(order);
            orderRepository.Save();

            // Return NoContent
            return NoContent();
        }

        // DELETE: api/Orders/16
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            // Delete order by ID and save
            var deleted = orderRepository.DeleteOrder(id);
            orderRepository.Save();

            //Return NoContent on success, otherwise NotFound
            return deleted ? NoContent() : NotFound();
        }
    }
}
