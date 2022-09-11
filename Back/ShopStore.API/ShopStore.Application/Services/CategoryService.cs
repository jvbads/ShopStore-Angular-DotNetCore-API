using AutoMapper;
using ShopStore.Application.DTO;
using ShopStore.Application.Interfaces;
using ShopStore.Domain.Entities;
using ShopStore.Repository.Interfaces;

namespace ShopStore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGeralRepository geralRepository,
                               ICategoryRepository categoryRepository,
                               IMapper mapper)
        {
            _geralRepository = geralRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto[]?> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();

                if (categories == null)
                    return null;

                return _mapper.Map<CategoryDto[]>(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

                if (category == null)
                    return null;

                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoryDto?> AddCategory(CategoryDto model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);

                _geralRepository.Add(category);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var categorySaved = await _categoryRepository.GetCategoryByIdAsync(category.Id);

                    return _mapper.Map<CategoryDto>(categorySaved);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoryDto?> UpdateCategory(int categoryId, CategoryDto model)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

                if (category == null)
                    return null;

                _mapper.Map(model, category);

                _geralRepository.Update(category);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var categorySaved = await _categoryRepository.GetCategoryByIdAsync(category.Id);

                    return _mapper.Map<CategoryDto>(categorySaved);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

                if (category == null) throw new Exception("Categoria não encontrada.");

                _geralRepository.Delete(category);

                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
