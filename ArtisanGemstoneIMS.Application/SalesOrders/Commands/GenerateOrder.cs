using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using ArtisanGemstoneIMS.Domain.SalesOrders;
using ArtisanGemstoneIMS.WebUI.Shared.SalesOrders;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace ArtisanGemstoneIMS.Application.SalesOrders.Commands;

public class GenerateOrderCommand : BaseSalesOrderDto, IRequest<Unit>
{

}

public class GenerateOrderCommandValidator : AbstractValidator<GenerateOrderCommand>
{
    public GenerateOrderCommandValidator()
    {
        Include(new BaseSalesOrderValidator());
    }
}

public class GenerateOrderCommandHandler : IRequestHandler<GenerateOrderCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public GenerateOrderCommandHandler(
        IMapper mapper,
        ISalesOrderRepository salesOrderRepository)
    {
        _mapper = mapper;
        _salesOrderRepository = salesOrderRepository;
    }

    public async Task<Unit> Handle(GenerateOrderCommand request, CancellationToken cancellationToken)
    {
        var validator = new GenerateOrderCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Sales Order", validationResult);

        var order = _mapper.Map<SalesOrder>(request);
        await _salesOrderRepository.GenerateOrderAsync(order);

        return Unit.Value;
    }
}
