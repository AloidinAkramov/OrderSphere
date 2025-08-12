using MerchManage.Data;
using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MerchManage.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Product> InsertProductAsync(Product product)
        {
            this.applicationDbContext.Entry(product).State = EntityState.Added;
            await this.applicationDbContext.SaveChangesAsync();

            return product;
        }

        public IQueryable<Product> SelectAllProducts()
        {
            return this.applicationDbContext.Products;
        }

        public async Task<Product?> SelectProductByIdAsync(Guid productId)
        {
            return await this.applicationDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            this.applicationDbContext.Entry(product).State = EntityState.Modified;
            await this.applicationDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            this.applicationDbContext.Entry(product).State = EntityState.Deleted;
            await this.applicationDbContext.SaveChangesAsync();

            return product;
        }
    }
}
