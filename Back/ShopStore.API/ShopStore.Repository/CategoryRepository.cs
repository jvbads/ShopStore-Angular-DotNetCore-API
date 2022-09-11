using Microsoft.EntityFrameworkCore;
using ShopStore.Domain.Entities;
using ShopStore.Repository.Context;
using ShopStore.Repository.Interfaces;

namespace ShopStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category[]> GetAllCategoriesAsync()
        {
            IQueryable<Category> query = _context.Categories.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            IQueryable<Category> query = _context.Categories.AsNoTracking().Where(c => c.Id == categoryId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
