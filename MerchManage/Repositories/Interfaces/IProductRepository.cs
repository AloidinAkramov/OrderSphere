using MerchManage.Models;

namespace MerchManage.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> InsertProductAsync(Product product);
        IQueryable<Product> SelectAllProducts();
        Task<Product> SelectProductByIdAsync(Guid productId);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> DeleteProductAsync(Product product);
    }
}
