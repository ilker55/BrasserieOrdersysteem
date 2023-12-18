using BrasserieOrdersysteem.Models;

namespace BrasserieOrdersysteem.DAL
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        bool DeleteOrder(int orderId);
        void Save();
    }
}
