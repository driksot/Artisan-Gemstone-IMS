using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.PurchaseOrders;
using ArtisanGemstoneIMS.WebUI.Shared.PurchaseOrders;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.PurchaseOrders.Commands;

public class GeneratePurchaseOrderCommand : BasePurchaseOrderDto, IRequest<Unit>
{

}

public class GeneratePurchaseOrderCommandValidator : AbstractValidator<GeneratePurchaseOrderCommand>
{
	public GeneratePurchaseOrderCommandValidator()
	{
		Include(new BasePurchaseOrderValidator());
	}
}

public class GeneratePurchaseOrderCommandHandler : IRequestHandler<GeneratePurchaseOrderCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public GeneratePurchaseOrderCommandHandler(
        IMapper mapper,
        IPurchaseOrderRepository purchaseOrderRepository)
    {
        _mapper = mapper;
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<Unit> Handle(GeneratePurchaseOrderCommand request, CancellationToken cancellationToken)
    {
        var validator = new GeneratePurchaseOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Purchase Order", validationResult);
        }

        var order = _mapper.Map<PurchaseOrder>(request);
        await _purchaseOrderRepository.GenerateOrderAsync(order);

        return Unit.Value;
    }
}
