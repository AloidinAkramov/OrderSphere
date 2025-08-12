using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using MerchManage.Services.Interfaces;

namespace MerchManage.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await this.customerRepository.InsertCustomerAsync(customer);
        }

        public IQueryable<Customer> RetrieveAllCustomers()
        {
            return this.customerRepository.SelectAllCustomers();
        }

        public async Task<Customer> RetrieveCustomerByIdAsync(Guid customerId)
        {
            var customer = await this.customerRepository.SelectCustomerByIdAsync(customerId);

            if (customer is null)
            {
                throw new KeyNotFoundException($"Customer with Id:{customerId} is not found");
            }

            return customer;
        }

        public async Task<Customer> ModifyCustomerAsync(Customer customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null");
            }

            var existingCustomer = await this.customerRepository.SelectCustomerByIdAsync(customer.Id);

            if (existingCustomer is null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            return await this.customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task<Customer> RemoveCustomerByIdAsync(Guid id)
        {
            var existingCustomer = await this.customerRepository.SelectCustomerByIdAsync(id);

            if (existingCustomer is null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            return await this.customerRepository.DeleteCustomerAsync(existingCustomer);
        }
    }
}
