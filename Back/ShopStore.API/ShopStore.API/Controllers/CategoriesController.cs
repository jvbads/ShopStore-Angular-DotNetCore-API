using Microsoft.AspNetCore.Mvc;
using ShopStore.Application.DTO;
using ShopStore.Application.Interfaces;

namespace ShopStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                if (categories == null)
                    return NoContent();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar buscar as categorias. Motivo: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category == null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar buscar a categoria. Motivo: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto model)
        {
            try
            {
                var category = await _categoryService.AddCategory(model);

                if (category == null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar a nova categoria. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryDto model)
        {
            try
            {
                var category = await _categoryService.UpdateCategory(id, model);

                if (category == null)
                    return NoContent();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar a categoria. Motivo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category == null)
                    return NoContent();

                if (await _categoryService.DeleteCategory(id))
                {
                    return Ok(new { message = "Categoria foi deletada com sucesso." });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao tentar deletar a categoria.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar deletar a categoria. Motivo: {ex.Message}");
            }
        }

    }
}
