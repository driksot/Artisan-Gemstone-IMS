using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Queries;

public record GetUnarchivedProductsListQuery : IRequest<List<ProductsListDto>>;

public class GetUnarchivedProductsListQueryHandler : IRequestHandler<GetUnarchivedProductsListQuery, List<ProductsListDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetUnarchivedProductsListQueryHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductsListDto>> Handle(GetUnarchivedProductsListQuery request, CancellationToken cancellationToken)
    {
        var unArchivedProducts = (await _productRepository.GetUnArchivedAsync()).ToList();
        var unArchivedProductDtos = _mapper.Map<List<ProductsListDto>>(unArchivedProducts);
        return unArchivedProductDtos;
    }
}
