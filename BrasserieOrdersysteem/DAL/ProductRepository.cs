using BrasserieOrdersysteem.DAL.Interfaces;
using BrasserieOrdersysteem.Models;

namespace BrasserieOrdersysteem.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderSystemContext context;

        public ProductRepository(OrderSystemContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        public IEnumerable<Product> GetAll()
            => context.Products.ToList();

        public Product? GetByID(int id)
            => context.Products.Find(id);
    }
}
