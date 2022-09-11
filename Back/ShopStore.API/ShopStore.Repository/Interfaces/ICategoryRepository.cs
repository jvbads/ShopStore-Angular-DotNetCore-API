using ShopStore.Domain.Entities;

namespace ShopStore.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category[]> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
    }
}
