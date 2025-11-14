using AutoMapper;
using store_api.DTOs;
using xbiz_store.Models;
namespace store_api.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                            .ForMember(dest => dest.Imagen,
                                opt => opt.MapFrom(src =>
                                    src.Imagen != null ? Convert.ToBase64String(src.Imagen) : string.Empty));

        }
    }
}
