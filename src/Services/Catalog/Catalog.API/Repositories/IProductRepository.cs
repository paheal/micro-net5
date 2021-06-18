using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {

        //CRUD Operations
        Task CreateProduct(Product product);
        Task<Product> GetProduct(string id);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

        //collections and search
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    }
}
