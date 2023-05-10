using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Queries;

public class GetProductDetailsQuery : IRequest<ProductDetailsDto>
{
    public Guid Id { get; set; }
}

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductDetailsQueryHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            throw new NotFoundException(nameof(product), request.Id);

        var productDetailsDto = _mapper.Map<ProductDetailsDto>(product);

        return productDetailsDto;
    }
}
