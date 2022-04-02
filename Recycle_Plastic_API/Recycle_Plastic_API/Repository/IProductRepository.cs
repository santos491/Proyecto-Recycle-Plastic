using Recycle_Plastic_API.Paging;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Repository
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid id);
        Task UpdateProduct(Product product, Product dbProduct);
        Task DeleteProduct(Product product);
    }
}
