using BrasserieOrdersysteem.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieOrdersysteem.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderSystemContext context;

        public OrderRepository(OrderSystemContext context)
            => this.context = context;

        public void AddOrder(Order order)
            => context.Orders.Add(order);

        public void UpdateOrder(Order order)
            => context.Entry(order).State = EntityState.Modified;

        public bool DeleteOrder(int orderId)
        {
            var order = context.Orders.Find(orderId);
            if (order == null) return false;
            context.Orders.Remove(order);
            return true;
        }

        public void Save() => context.SaveChanges();
    }
}
