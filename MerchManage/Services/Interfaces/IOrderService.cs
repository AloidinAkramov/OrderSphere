using MerchManage.Models;

namespace MerchManage.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order order);
        IQueryable<Order> RetrieveAllOrders();
        Task<Order> RetrieveOrderByIdAsync(Guid orderId);
        Task<Order> ModifyOrderAsync(Order order);
        Task<Order> RemoveOrderByIdAsync(Guid id);
    }
}
