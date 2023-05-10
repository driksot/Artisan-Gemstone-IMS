using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Commands;

public class ArchiveProductCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class ArchiveProductCommandHandler : IRequestHandler<ArchiveProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public ArchiveProductCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(ArchiveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            throw new NotFoundException(nameof(product), request.Id);

        await _productRepository.ArchiveAsync(product.Id);
        return Unit.Value;
    }
}
