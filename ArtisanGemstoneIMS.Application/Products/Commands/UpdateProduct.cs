using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.WebUI.Shared.Products;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.Products.Commands;

public class UpdateProductCommand : BaseProductDto, IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        Include(new BaseProductValidator());
    }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(
        IMapper mapper,
        IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
            throw new NotFoundException(nameof(product), request.Id);

        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Product", validationResult);

        _mapper.Map(request, product);

        await _productRepository.UpdateAsync(product);

        return Unit.Value;
    }
}
