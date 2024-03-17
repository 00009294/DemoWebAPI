using DemoWebAPI.Models;

namespace DemoWebAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync(string name);
        Task<List<Product>> GetAllAsync();
        Task<Result> CreateAsync(Product product);
        Task<Result> UpdateAsync(Guid id, Product product);
        Task<Result> DeleteAsync(Guid id);
    }
}
