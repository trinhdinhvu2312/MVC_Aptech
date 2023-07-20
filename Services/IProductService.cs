using MVC_Aptech.Models;
using MVC_Aptech.Models.DTOs;

namespace MVC_Aptech.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(int page, int limit);
        Product? GetProductById(int id);
        void CreateProduct(ProductDTO productDTO);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
