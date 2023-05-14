using ArtisanGemstoneIMS.Application.Common.Exceptions;
using ArtisanGemstoneIMS.Application.Contracts.Persistence;
using MediatR;

namespace ArtisanGemstoneIMS.Application.SalesOrders.Commands;

public class MarkOrderFulfilledCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public class MarkOrderFulfilledCommandHandler : IRequestHandler<MarkOrderFulfilledCommand, Unit>
{
    private readonly ISalesOrderRepository _salesOrderRepository;

    public MarkOrderFulfilledCommandHandler(
        ISalesOrderRepository salesOrderRepository)
    {
        _salesOrderRepository = salesOrderRepository;
    }

    public async Task<Unit> Handle(MarkOrderFulfilledCommand request, CancellationToken cancellationToken)
    {
        var order = await _salesOrderRepository.GetByIdAsync(request.Id);

        if (order == null)
            throw new NotFoundException(nameof(order), request.Id);

        await _salesOrderRepository.MarkFulfilledAsync(order.Id);
        return Unit.Value;
    }
}
