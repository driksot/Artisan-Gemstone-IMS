using ArtisanGemstoneIMS.Application.Products.Commands;
using ArtisanGemstoneIMS.Domain.Products;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;

namespace ArtisanGemstoneIMS.Application.Products;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductsListDto>().ReverseMap();
        CreateMap<Product, ProductDetailsDto>().ReverseMap();
        CreateMap<BaseProductDto, Product>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
