using Microsoft.AspNetCore.Mvc;
using ShopStore.Application.DTO;
using ShopStore.Application.Interfaces;

namespace ShopStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync(true);
                 
                if (products == null)
                    return NoContent();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar buscar os produtos. Motivo: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductsByIdAsync(id, true);

                if (product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar buscar produto. Motivo: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto model)
        {
            try
            {   
                var product = await _productService.AddProduct(model);

                if (product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar novo produto. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductDto model)
        {
            try
            {
                var product = await _productService.UpdateProduct(id, model);

                if (product == null)
                    return NoContent();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar o produto. Motivo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.GetProductsByIdAsync(id, true);

                if (product == null)
                    return NoContent();

                if (await _productService.DeleteProduct(id))
                {
                    // TODO: Lembrar de deletar a imagem

                    return Ok(new { message = "Produto foi deletado com sucesso." });
                }
                else
                {
                    throw new Exception("Ocorreu um problema ao tentar deletar o produto.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar deletar o produto. Motivo: {ex.Message}");
            }
        }
    }
}
