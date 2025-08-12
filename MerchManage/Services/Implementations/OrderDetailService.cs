using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using MerchManage.Services.Interfaces;

namespace MerchManage.Services.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            return await this.orderDetailRepository.InsertOrderDetailAsync(orderDetail);
        }

        public IQueryable<OrderDetail> RetrieveAllOrderDetails()
        {
            return this.orderDetailRepository.SelectAllOrderDetails();
        }

        public async Task<OrderDetail> RetrieveOrderDetailByIdAsync(Guid orderDetailId)
        {
            var orderDetail = await this.orderDetailRepository.SelectOrderDetailByIdAsync(orderDetailId);

            if (orderDetail is null)
            {
                throw new KeyNotFoundException($"OrderDetail with Id:{orderDetailId} is not found");
            }

            return orderDetail;
        }

        public async Task<OrderDetail> ModifyOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail is null)
            {
                throw new ArgumentNullException(nameof(orderDetail), "OrderDetail cannot be null");
            }

            var existingOrderDetail = await this.orderDetailRepository.SelectOrderDetailByIdAsync(orderDetail.Id);

            if (existingOrderDetail is null)
            {
                throw new KeyNotFoundException("OrderDetail not found");
            }

            return await this.orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
        }

        public async Task<OrderDetail> RemoveOrderDetailByIdAsync(Guid id)
        {
            var existingOrderDetail = await this.orderDetailRepository.SelectOrderDetailByIdAsync(id);

            if (existingOrderDetail is null)
            {
                throw new KeyNotFoundException("OrderDetail not found");
            }

            return await this.orderDetailRepository.DeleteOrderDetailAsync(existingOrderDetail);
        }
    }
}
