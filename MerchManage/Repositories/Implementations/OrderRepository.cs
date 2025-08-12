using MerchManage.Data;
using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchManage.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Order> InsertOrderAsync(Order order)
        {
            this.applicationDbContext.Entry(order).State = EntityState.Added;
            await this.applicationDbContext.SaveChangesAsync();

            return order;
        }

        public IQueryable<Order> SelectAllOrders()
        {
            return this.applicationDbContext.Orders;
        }

        public async Task<Order> SelectOrderByIdAsync(Guid orderId)
        {
            return await this.applicationDbContext.Orders.FirstOrDefaultAsync(
                order => order.Id == orderId);
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            this.applicationDbContext.Entry(order).State = EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> DeleteOrderAsync(Order order)
        {
            this.applicationDbContext.Entry(order).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return order;
        }
    }
}
