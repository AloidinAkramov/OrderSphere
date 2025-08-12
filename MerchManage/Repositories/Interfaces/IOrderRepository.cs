using MerchManage.Models;

namespace MerchManage.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> InsertOrderAsync(Order order);
        IQueryable<Order> SelectAllOrders();
        Task<Order> SelectOrderByIdAsync(Guid orderId);
        Task<Order> UpdateOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(Order order);
    }
}
