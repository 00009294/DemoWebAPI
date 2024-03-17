using DemoWebAPI.Models;

namespace DemoWebAPI.Repostories
{
    public interface IProductRepository
    {
        List<Product> GetAll(string name);
        List<Product> GetAll();
        Product GetById(Guid id);
        Result Create(Product product);
        Result Update(Guid id, Product product);
        Result Delete(Guid id);
    }
}
