using MerchManage.Models;
using MerchManage.Repositories.Interfaces;
using MerchManage.Services.Interfaces;

namespace MerchManage.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await this.productRepository.InsertProductAsync(product);
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return this.productRepository.SelectAllProducts();
        }

        public async Task<Product> RetrieveProductByIdAsync(Guid productId)
        {
            var product = await this.productRepository.SelectProductByIdAsync(productId);

            if (product is null)
            {
                throw new KeyNotFoundException($"Product with Id:{productId} is not found");
            }

            return product;
        }

        public async Task<Product> ModifyProductAsync(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null");
            }

            var existingProduct = await this.productRepository.SelectProductByIdAsync(product.Id);

            if (existingProduct is null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return await this.productRepository.UpdateProductAsync(product);
        }

        public async Task<Product> RemoveProductByIdAsync(Guid id)
        {
            var existingProduct = await this.productRepository.SelectProductByIdAsync(id);

            if (existingProduct is null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return await this.productRepository.DeleteProductAsync(existingProduct);
        }
    }
}
