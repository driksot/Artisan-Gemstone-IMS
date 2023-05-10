using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Queries;

public record GetProductsListQuery : IRequest<List<ProductsListDto>>;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductsListDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductsListQueryHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductsListDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var products = (await _productRepository.GetAsync()).ToList();
        var productsListDtos = _mapper.Map<List<ProductsListDto>>(products);
        return productsListDtos;
    }
}
