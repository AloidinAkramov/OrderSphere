using MerchManage.Models;

namespace MerchManage.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> InsertCustomerAsync(Customer customer);
        IQueryable<Customer> SelectAllCustomers();
        Task<Customer> SelectCustomerByIdAsync(Guid customerId);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<Customer> DeleteCustomerAsync(Customer customer);
    }
}
