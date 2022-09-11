using AutoMapper;
using ShopStore.Application.DTO;
using ShopStore.Application.Interfaces;
using ShopStore.Domain.Entities;
using ShopStore.Repository.Interfaces;

namespace ShopStore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGeralRepository geralRepository,
                              IProductRepository productRepository,
                              IMapper mapper)
        {
            _geralRepository = geralRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto[]?> GetAllProductsAsync(bool includeCategory = false)
        {
            try
            {
                var products = await _productRepository.GetAllProductsAsync(includeCategory);

                if (products == null)
                    return null;

                return _mapper.Map<ProductDto[]>(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductDto?> GetProductsByIdAsync(int productId, bool includeCategory = false)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId, includeCategory);

                if (product == null)
                    return null;

                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductDto?> AddProduct(ProductDto model)
        {
            try
            {
                var product = _mapper.Map<Product>(model);

                _geralRepository.Add(product);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var productSaved = await _productRepository.GetProductByIdAsync(product.Id);

                    return _mapper.Map<ProductDto>(productSaved);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProductDto?> UpdateProduct(int productId, ProductDto model)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId);

                if (product == null)
                    return null;

                _mapper.Map(model, product);

                _geralRepository.Update(product);

                if (await _geralRepository.SaveChangesAsync())
                {
                    var productSaved = await _productRepository.GetProductByIdAsync(product.Id);

                    return _mapper.Map<ProductDto>(productSaved);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId, false);

                if (product == null)
                    throw new Exception("Produto não encontrado.");

                _geralRepository.Delete(product);

                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
