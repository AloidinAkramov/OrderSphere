using MerchManage.Data;
using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchManage.Repositories.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderDetailRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<OrderDetail> InsertOrderDetailAsync(OrderDetail orderDetail)
        {
            this.applicationDbContext.Entry(orderDetail).State = EntityState.Added;
            await this.applicationDbContext.SaveChangesAsync();

            return orderDetail;
        }

        public IQueryable<OrderDetail> SelectAllOrderDetails()
        {
            return this.applicationDbContext.OrderDetails;
        }

        public async Task<OrderDetail?> SelectOrderDetailByIdAsync(Guid orderDetailId)
        {
            return await this.applicationDbContext.OrderDetails
                .FirstOrDefaultAsync(od => od.Id == orderDetailId);
        }

        public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            this.applicationDbContext.Entry(orderDetail).State = EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return orderDetail;
        }

        public async Task<OrderDetail> DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            this.applicationDbContext.Entry(orderDetail).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return orderDetail;
        }
    }
}