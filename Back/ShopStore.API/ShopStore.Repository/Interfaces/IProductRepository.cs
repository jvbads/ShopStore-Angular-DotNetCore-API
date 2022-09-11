using ShopStore.Domain.Entities;

namespace ShopStore.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllProductsAsync(bool includeCategory = false);
        Task<Product> GetProductByIdAsync(int productId, bool includeCategory = false);
    }
}
