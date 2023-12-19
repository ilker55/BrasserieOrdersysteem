using BrasserieOrdersysteem.Models;

namespace BrasserieOrdersysteem.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetByID(int id);
    }
}
