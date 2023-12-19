using BrasserieOrdersysteem.Models;

namespace BrasserieOrdersysteem.DAL
{
    public interface ICrudRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetByID(int id);
        void Insert(T model);
        void Update(T model);
        bool Delete(int id);
        void Save();
    }
}
