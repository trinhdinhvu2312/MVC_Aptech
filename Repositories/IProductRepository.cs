using MVC_Aptech.Models;

namespace MVC_Aptech.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int page, int limit);
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
