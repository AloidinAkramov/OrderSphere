using MerchManage.Models;

namespace MerchManage.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail);
        IQueryable<OrderDetail> RetrieveAllOrderDetails();
        Task<OrderDetail> RetrieveOrderDetailByIdAsync(Guid orderDetailId);
        Task<OrderDetail> ModifyOrderDetailAsync(OrderDetail orderDetail);
        Task<OrderDetail> RemoveOrderDetailByIdAsync(Guid id);
    }
}
