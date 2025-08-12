using MerchManage.Data;
using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchManage.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            this.applicationDbContext.Entry(customer).State = EntityState.Added;
            await this.applicationDbContext.SaveChangesAsync();

            return customer;
        }

        public IQueryable<Customer> SelectAllCustomers()
        {
            return this.applicationDbContext.Customers;
        }

        public async Task<Customer> SelectCustomerByIdAsync(Guid customerId)
        {
            return await this.applicationDbContext.Customers.FirstOrDefaultAsync(
                customer => customer.Id == customerId);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            this.applicationDbContext.Entry(customer).State |= EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(Customer customer)
        {
            this.applicationDbContext.Entry(customer).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return customer;
        }
    }
}