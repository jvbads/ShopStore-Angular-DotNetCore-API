using ShopStore.Application.DTO;

namespace ShopStore.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddCategory(CategoryDto model);
        Task<CategoryDto> UpdateCategory(int categoryId, CategoryDto model);
        Task<bool> DeleteCategory(int categoryId);

        Task<CategoryDto[]> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
    }
}
