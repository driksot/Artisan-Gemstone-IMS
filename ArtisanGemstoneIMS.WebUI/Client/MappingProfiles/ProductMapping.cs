using ArtisanGemstoneIMS.Application.Products.Commands;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;

namespace ArtisanGemstoneIMS.WebUI.Client.MappingProfiles;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<ProductDetailsDto, CreateProductCommand>();
        CreateMap<ProductDetailsDto, UpdateProductCommand>();
    }
}
