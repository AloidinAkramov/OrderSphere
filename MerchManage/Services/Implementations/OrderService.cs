using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using MerchManage.Services.Interfaces;

namespace MerchManage.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            return await this.orderRepository.InsertOrderAsync(order);
        }

        public IQueryable<Order> RetrieveAllOrders()
        {
            return this.orderRepository.SelectAllOrders();
        }

        public async Task<Order> RetrieveOrderByIdAsync(Guid orderId)
        {
            var order = await this.orderRepository.SelectOrderByIdAsync(orderId);

            if (order is null)
            {
                throw new KeyNotFoundException($"Order with Id:{orderId} is not found");
            }

            return order;
        }

        public async Task<Order> ModifyOrderAsync(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null");
            }

            var existingOrder = await this.orderRepository.SelectOrderByIdAsync(order.Id);

            if (existingOrder is null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            return await this.orderRepository.UpdateOrderAsync(order);
        }

        public async Task<Order> RemoveOrderByIdAsync(Guid id)
        {
            var existingOrder = await this.orderRepository.SelectOrderByIdAsync(id);

            if (existingOrder is null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            return await this.orderRepository.DeleteOrderAsync(existingOrder);
        }
    }
}
