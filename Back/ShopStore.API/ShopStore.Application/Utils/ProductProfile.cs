using AutoMapper;
using ShopStore.Application.DTO;
using ShopStore.Domain.Entities;

namespace ShopStore.Application.Utils
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
