using Microsoft.EntityFrameworkCore;
using ShopStore.Domain.Entities;
using ShopStore.Repository.Context;
using ShopStore.Repository.Interfaces;

namespace ShopStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product[]> GetAllProductsAsync(bool includeCategory = false)
        {
            IQueryable<Product> query = _context.Products.AsNoTracking();

            if (includeCategory)
                query = query.Include(e => e.Category);

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId, bool includeCategory = false)
        {
            IQueryable<Product> query = _context.Products.AsNoTracking();

            if (includeCategory)
                query = query.Include(e => e.Category);

            query = query.OrderBy(e => e.Id).Where(e => e.Id == productId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
