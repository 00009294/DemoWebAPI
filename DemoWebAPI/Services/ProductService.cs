using DemoWebAPI.Models;
using DemoWebAPI.Repostories;

namespace DemoWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Result> CreateAsync(Product product)
        {
            return this.productRepository.Create(product);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            return this.productRepository.Delete(id);
        }

        public async Task<List<Product>> GetAllAsync(string name)
        {
            return this.productRepository.GetAll(name);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return this.productRepository.GetAll();
        }

        public async Task<Result> UpdateAsync(Guid id, Product product)
        {
            return this.productRepository.Update(id, product);
        }
    }
}
