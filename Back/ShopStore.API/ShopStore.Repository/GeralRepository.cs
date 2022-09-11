using ShopStore.Repository.Context;
using ShopStore.Repository.Interfaces;

namespace ShopStore.Repository
{
    public class GeralRepository : IGeralRepository
    {
        public readonly DataContext _context;
        public GeralRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);    
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);    
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
