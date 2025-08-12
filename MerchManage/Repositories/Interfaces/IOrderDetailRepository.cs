using MerchManage.Models;

namespace MerchManage.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> InsertOrderDetailAsync(OrderDetail orderDetail);
        IQueryable<OrderDetail> SelectAllOrderDetails();
        Task<OrderDetail> SelectOrderDetailByIdAsync(Guid orderDetailId);
        Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail);
        Task<OrderDetail> DeleteOrderDetailAsync(OrderDetail orderDetail);
    }
}
