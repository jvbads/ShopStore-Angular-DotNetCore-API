using ShopStore.Application.DTO;

namespace ShopStore.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> AddProduct(ProductDto model);
        Task<ProductDto> UpdateProduct(int productId, ProductDto model);
        Task<bool> DeleteProduct(int ProductId);

        Task<ProductDto[]> GetAllProductsAsync(bool includeCategory = false);
        Task<ProductDto> GetProductsByIdAsync(int productId, bool includeCategory = false);
    }
}
