using Recycle_Plastic_API.Context;
using Recycle_Plastic_API.Paging;
using Recycle_Plastic_API.Repository.RepositoryExtensions;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Recycle_Plastic_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
        {
            var products = await _context.Products
                .Search(productParameters.SearchTerm)
                //.Sort(productParameters.OrderBy)
                .ToListAsync();

            return PagedList<Product>
                .ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
        }

        public async Task CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(Guid id) => 
            await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

        public async Task UpdateProduct(Product product, Product dbProduct)
        {
            dbProduct.Name = product.Name;
            dbProduct.materials = product.materials;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.description = product.description;
            dbProduct.contact = product.contact;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
