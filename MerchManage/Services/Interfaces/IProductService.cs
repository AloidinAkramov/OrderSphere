using MerchManage.Models;

namespace MerchManage.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProducts();
        Task<Product> RetrieveProductByIdAsync(Guid productId);
        Task<Product> ModifyProductAsync(Product product);
        Task<Product> RemoveProductByIdAsync(Guid id);
    }
}
