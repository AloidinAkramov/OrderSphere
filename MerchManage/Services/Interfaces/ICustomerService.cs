using MerchManage.Models;

namespace MerchManage.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        IQueryable<Customer> RetrieveAllCustomers();
        Task<Customer> RetrieveCustomerByIdAsync(Guid customerId);
        Task<Customer> ModifyCustomerAsync(Customer customer);
        Task<Customer> RemoveCustomerByIdAsync(Guid id);
    }
}
