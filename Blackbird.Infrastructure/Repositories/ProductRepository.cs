using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blackbird.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BlackbirdDbContext _dbContext;

        public ProductRepository(BlackbirdDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
