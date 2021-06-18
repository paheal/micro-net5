using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<Product> GetProduct(string id)
        {
            var result = await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult =
                await _context.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

            bool wasSuccessful = updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;

            return wasSuccessful;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p =>
                p.Id, id);
            DeleteResult result = await _context.Products.DeleteOneAsync(filter);

            bool wasSuccessful = result.IsAcknowledged && result.DeletedCount > 0;

            return wasSuccessful;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result =  await _context.Products.Find(p => true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p =>
                p.Name, name);
            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p =>
                p.Category, categoryName);
            var result = await _context.Products.Find(filter).ToListAsync();
            return result;
        }
    }
}
