using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieOrdersysteem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
            => this.productRepository = productRepository;

        // GET: api/Products
        [HttpGet]
        public ActionResult<IList<Product>> GetProducts()
            // Return all products
            => productRepository.GetAll().ToList();

        // GET: api/Products/3
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            // Return product found by ID, otherwise NotFound
            var product = productRepository.GetByID(id);
            return product != null ? product : NotFound();
        }
    }
}
