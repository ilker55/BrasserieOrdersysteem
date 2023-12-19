using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderSystemContext context;

        public OrderRepository(OrderSystemContext context)
            => this.context = context;

        public IEnumerable<Order> GetAll()
            => context.Orders;

        public Order? GetByID(int id)
            => context.Orders.Find(id);

        public void Insert(Order order)
            => context.Orders.Add(order);

        public void Update(Order order)
            => context.Entry(order).State = EntityState.Modified;

        public bool Delete(int orderId)
        {
            var order = context.Orders.Find(orderId);
            if (order == null) return false;
            context.Orders.Remove(order);
            return true;
        }

        public void Save() => context.SaveChanges();
    }
}
