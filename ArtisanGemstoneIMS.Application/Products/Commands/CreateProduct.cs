using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.Products;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Commands;

public class CreateProductCommand : BaseProductDto, IRequest<Unit>
{
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        Include(new BaseProductValidator());
    }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Product", validationResult);

        var product = _mapper.Map<Product>(request);
        await _productRepository.CreateProductWithInventory(product);

        return Unit.Value;
    }
}
